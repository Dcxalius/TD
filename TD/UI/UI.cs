using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    static class UI
    {
        public static Button buildButton = new BuildButton(new Vector2(TextureManager.unpressedButton.Width / 2,100));

        public static List<DataBox> dataBoxes = new List<DataBox>();
        public static List<Button> dataButtons = new List<Button>();

        public static TowerTemplate targetTower;
        public static Item targetItem;
        static bool releasedItem = false;

        public static bool ItemReleased
        {
            get => releasedItem;
        }


        public static void Update()
        {
            buildButton.Update();
            foreach (Button button in dataButtons)
            {
                button.Update();
            }
            List<UIObject> sendables = new List<UIObject>();
            sendables.AddRange(dataBoxes);
            sendables.AddRange(dataButtons);
            sendables.Add(buildButton);
            GFXManager.DrawUIToUIRenderer(sendables.ToArray());

            if (targetItem != null && releasedItem == false)
            {
                targetItem.MoveTo(InputManager.MousePositionAsVector);

                if (InputManager.SingleLeftRelease())
                {

                    targetItem.ResetPosition();
                    foreach (Tower tower in TowerManager.Towers)
                    {
                        if (tower.HitRectangle.Contains(InputManager.MousePosition))
                        {
                            if (tower.ItemID.HasValue)
                            {
                                if (tower.ItemID == targetItem.ID)
                                {
                                    break;
                                }
                            }
                            targetItem.AssignPosition(tower);
                            Inventory.RemoveItem(targetItem);
                            Item returningItem = tower.EquipItem(targetItem);
                            if (returningItem != null)
                            {
                                Inventory.AddItemToInventory(returningItem);
                            }
                            ClearTargets();
                            break;
                        }
                    }
                    releasedItem = true;
                }
            }
            if (targetItem == null && targetTower == null && dataButtons.Count == 0)
            {
                dataButtons.Add(new LevelUpButton(new Vector2(TextureManager.unpressedButton.Width / 2, GFXManager.ScreenHeight - (int)Tower.AttackDataType.count * 50 - 40)));
            }
        }

        public static void TargetNewItem(Item aItem)
        {
            ClearTargets();
            releasedItem = false;
            targetItem = aItem;
            for (int i = 0; i < 3; i++)
            {
                dataBoxes.Add(new DataBox(targetItem.ItemData[i], new Vector2(0, GFXManager.ScreenHeight - 50 * 3 + (i + 1) * 50)));
            }
            float x = TextureManager.unpressedButton.Width / 2;
            float y = GFXManager.ScreenHeight - 150 - 40;
            dataButtons.Add(new SellButton(new Vector2(x, y - 160)));
            dataButtons.Add(new MergeButton(new Vector2(x, y - 80)));
        }

        public static void TargetNewTower(TowerTemplate aTower)
        {
            targetTower = aTower;
            for (int i = 0; i < (int)TowerTemplate.AttackDataType.count; i++)
            {
                dataBoxes.Add(new DataBox(targetTower.AttackData[i], new Vector2(0, GFXManager.ScreenHeight - i * 50)));
                    
            }
            float x = TextureManager.unpressedButton.Width / 2;
            float y = GFXManager.ScreenHeight - (int)Tower.AttackDataType.count * 50 - 40;
            dataButtons.Add(new IncreaseDamageButton(new Vector2(x, y)));
            dataButtons.Add(new IncreaseAttackSpeedButton(new Vector2(x, y - 80)));
            dataButtons.Add(new IncreaseRangeButton(new Vector2(x, y - 160)));
        }

        public static void ClearTargets()
        {
            dataBoxes.Clear();
            dataButtons.Clear();
            Inventory.mergeSwitch = false;
            targetTower = null;

            if (targetItem != null)
            {
                targetItem.ResetPosition();
            }
            targetItem = null;

        }

        public static void UpdateBox(TowerTemplate.AttackDataType aType)
        {
            dataBoxes[(int) aType].Update(targetTower.AttackData[(int)aType]);
        }

        public static void Draw(SpriteBatch aBatch)
        {
            if (targetItem != null && releasedItem == false)
            {
                targetItem.Draw(aBatch);
            }
        }
    }
}
