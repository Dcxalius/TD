using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class Item : UIObject
    {
        

        public enum Type
        {
            Rocket,
            Freeze,
            Snipe,
            Count
        }

        int[] amountOfTypes = new int[(int)Type.Count];

        public int[] AmountOfTypes
        {
            get => amountOfTypes;
        }

        public int ActiveTypes
        {
            get
            {
                int amount = 0;
                for (int i = 0; i < (int)Type.Count; i++)
                {
                    if (amountOfTypes[i] > 0)
                    {
                        amount++;
                    }
                }
                return amount;
            }
        }

        public Type GetAnyActive
        {
            get
            {
                for (int i = 0; i < (int)Type.Count; i++)
                {
                    if (amountOfTypes[i] > 0)
                    {
                        return (Type)i;
                    }
                }
                return Type.Count;
            }
        }

        public Type TypeWithMajority
        {
            get
            {
                int totalTypes = 0;
                Type mostFrequent = Type.Count;
                int mostFrequentAmount = 0;
                for (int i = 0; i < (int) Type.Count; i++)
                {
                    if (mostFrequentAmount < amountOfTypes[i])
                    {
                        mostFrequentAmount = amountOfTypes[i];
                        mostFrequent = (Type) i;
                    }
                    totalTypes += amountOfTypes[i];
                }

                if (mostFrequentAmount < totalTypes / 2)
                {
                    return Type.Count;
                }

                return mostFrequent;
            }
            
        }

        List<Data> itemData = new List<Data>();
        public List<Data> ItemData
        {
            get => itemData;
        }

        int rank;
        static int nextID = 0;
        int id;
        Vector2 homePosition;

        public int Rank
        {
            get => rank;
        }
        private static int GetId
        {
            get
            {
                return ++nextID;
            }
        }
        public int ID
        {
            get => id;
        }

        public Item(Type aType, int aRank)
        {
            amountOfTypes[(int)aType] += (int) Math.Pow(2, aRank); 
            SetGfx(aType);
            rank = aRank;
            Init();
            itemData[(int)aType].RefreshItemData(amountOfTypes[(int) aType], rank);
        }

        public Item(Item aItem, Item anItem)
        {
            for (int i = 0; i < (int)Type.Count; i++)
            {
                amountOfTypes[i] = aItem.amountOfTypes[i] + anItem.amountOfTypes[i];
            }
            SetGfx(TypeWithMajority);
            rank = ++aItem.rank;
            Init();
            for (int i = 0; i < (int)Type.Count; i++)
            {
                itemData[i].RefreshItemData(amountOfTypes[i], rank);

            }

            ResetPosition();
        }

        void SetGfx(Type aType)
        {
            switch (aType)
            {
                case Type.Rocket:
                    gfx = TextureManager.rocketEmblem;
                    break;
                case Type.Freeze:
                    gfx = TextureManager.freezeEmblem;
                    break;
                case Type.Snipe:
                    gfx = TextureManager.sniperEmblem;
                    break;
                default:
                    gfx = TextureManager.superEmblem;
                    break;
            }
        }
        private void Init()
        {
            id = GetId;
            offset = gfx.Bounds.Size.ToVector2() / 2;
            drawRectangle = new Rectangle(Point.Zero, gfx.Bounds.Size);
            itemData.Add(new Data(0, 0, 100, "radius"));
            itemData.Add(new Data(1, 1, 0.1f, "sec slow"));
            itemData.Add(new Data(1, 1, 0.5f, "* crit dmg"));
        }

        public void Update()
        {
            if (InputManager.SingleLeftClick(HitRectangle))
            {
                if (StateManager.currentState == StateManager.GameState.Game)
                {
                    if (Inventory.mergeSwitch == true && UI.targetItem.rank == rank)
                    {
                        Inventory.RemoveItem(this);
                        Inventory.AddItemToInventory(new Item(UI.targetItem, this));
                        Inventory.RemoveItem(UI.targetItem);
                        UI.ClearTargets();
                    }
                    else
                    {
                        UI.TargetNewItem(this);
                    }
                }
            }
        }

        public void ResetPosition()
        {
            position = homePosition;
        }

        public void AssignPosition(TowerTemplate aTower)
        {
            homePosition = aTower.Position;
            position = homePosition;
            hitRectangle = new Rectangle((position - offset).ToPoint(), gfx.Bounds.Size);
        }

        public void MoveTo(Vector2 aPosition)
        {
            position = aPosition;
        }

        public void AssignPosition(int aIndex)
        {
            homePosition = Inventory.ItemSlot(aIndex);
            position = homePosition;
            hitRectangle = new Rectangle((position - offset + new Vector2(GFXManager.UIROffsetX, 0)).ToPoint(), gfx.Bounds.Size);
        }

        

        public override void Draw(SpriteBatch aBatch)
        {
            if (UI.targetItem != null && UI.targetItem.ID == ID)
            {
                if (UI.ItemReleased == false)
                {
                    aBatch.Draw(gfx, InputManager.MousePositionAsVector, drawRectangle, color, rotation, offset, scale, SpriteEffects.None, 1f);
                }
                else
                {
                    base.Draw(aBatch);
                    aBatch.Draw(TextureManager.targetedItem, position, null, color, rotation, TextureManager.targetedItem.Bounds.Size.ToVector2() / 2, scale, SpriteEffects.None, 1f);
                }
            }
            else
            {
                if (Inventory.mergeSwitch == true)
                {
                    if (rank == UI.targetItem.rank)
                    {
                        aBatch.Draw(TextureManager.targetedItem, position, null, color, rotation, TextureManager.targetedItem.Bounds.Size.ToVector2() / 2, scale, SpriteEffects.None, 1f); //TODO: Change texture

                    }
                }
                base.Draw(aBatch);

            }
        }
    }
}
