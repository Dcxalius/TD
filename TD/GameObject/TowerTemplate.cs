using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD
{
    class TowerTemplate : GameObject
    {
        public const int Size = 64;
        static float price = 50;

        public enum AttackDataType
        {
            damage,
            attackSpeed,
            range,
            count
        }


        protected Projectile.DamageMessage damageMessage;

        protected float attacks;

        Item equipedItem;


        static public float Price
        {
            get => price;
        }

        public int? ItemID
        {
            get
            {
                if (equipedItem != null)
                {
                    return equipedItem.ID;
                }

                return null;
            }
        }



        List<Data> attackData = new List<Data>();

        public void IncreaseData(AttackDataType dataType)
        {
            attackData[(int)dataType].IncreaseData();
            if (dataType == (int)AttackDataType.damage)
            {
                WriteDamageMessage();
            }
        }

        public List<Data> AttackData
        {
            get => attackData;
        }

        public TowerTemplate()
        {
            attackData.Add(new Data(10, 5, 1, "damage"));
            damageMessage = new Projectile.DamageMessage(attackData[(int)AttackDataType.damage].value, new float[(int)Item.Type.Count]);
            attackData.Add(new Data(10, 1 / 100f, 1 / 450f, "a / f"));
            attackData.Add(new Data(10, 100, 10, "units"));
            attacks = 0f;
            price *= 2f;
        }

        public void Update()
        {

            if (attacks >= 1)
            {
                Monster target = MonsterManager.GetFurthestMonsterInRangeOfPosition(position, attackData[(int)AttackDataType.range].value);
                if (target != null)
                {
                    int tempAttacks = (int)Math.Floor(attacks);
                    for (int i = 0; i < tempAttacks; i++)
                    {
                        attacks--;
                        if (equipedItem != null)
                        {
                            ProjectileManager.AddProjectile(position, target, damageMessage, equipedItem.TypeWithMajority);
                        }
                        else
                        {
                            ProjectileManager.AddProjectile(position, target, damageMessage);
                        }

                    }
                }
            }
            else
            {
                attacks += attackData[(int)AttackDataType.attackSpeed].value;

            }

            if (equipedItem != null)
            {
                equipedItem.Update();
            }
        }

        

        public Item EquipItem(Item aItem)
        {
            if (Inventory.mergeSwitch == true && equipedItem != null && equipedItem.Rank == aItem.Rank)
            {
                equipedItem = new Item(equipedItem, aItem);
                return null;
            }
            Item tempItem = equipedItem;
            equipedItem = aItem;
            WriteDamageMessage();
            return tempItem;
        }

        public void WriteDamageMessage()
        {
            damageMessage.damage = attackData[(int)AttackDataType.damage].value;
            for (int i = 0; i < (int)Item.Type.Count; i++)
            {
                if (equipedItem != null)
                {
                    damageMessage.type[i] = equipedItem.ItemData[i].value;
                }
            }
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);

            if (equipedItem != null)
            {
                equipedItem.Draw(aBatch);
            }
        }
    }
}
