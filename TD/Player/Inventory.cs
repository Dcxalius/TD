using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WinForm;

namespace TD
{
    static class Inventory
    {
        const int NrItemSlots = 9;

        public static bool mergeSwitch = false;

        static Item[] items = new Item[NrItemSlots];
        static Vector2[] itemSlots = new Vector2[NrItemSlots];

        public static void Init()
        {
            double sqrt = Math.Sqrt(NrItemSlots);
            Vector2 startVector = new Vector2(33, 173);
            for (int i = 0; i < NrItemSlots / sqrt; i++)
            {
                for (int j = 0; j < NrItemSlots / sqrt; j++)
                {
                    itemSlots[(int)(i % sqrt + Math.Floor(j * sqrt))] = startVector + new Vector2(i % (float)sqrt * 67.4f, (float)j * 62);
                }
            }
        }

        public static void Update()
        {
            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (items[i] != null)
                {
                    items[i].Update(); 
                }

            }
        }

        public static Vector2 ItemSlot(int aIndex)
        {
            return itemSlots[aIndex];
        }

        public static bool AddItemToInventory(Item aItem)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = aItem;
                    items[i].AssignPosition(i);
                    return true;
                }
            }

            return false;
        }

        public static void RemoveItem(Item aItem)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (aItem.ID == items[i].ID)
                    {
                        items[i] = null;
                    }
                }
            }
        }

        public static void Draw(SpriteBatch aBatch)
        {
            foreach (Item item in items)
            {
                if (item != null)
                {
                    item.Draw(aBatch);
                }
            }
        }
    }
}
