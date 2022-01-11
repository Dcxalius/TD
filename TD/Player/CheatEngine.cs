using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm;

namespace TD
{
    static class CheatEngine
    {
        static Form1 cheatForm = new Form1();

        public static void Update()
        {
            if (InputManager.SingleKeyPress(Microsoft.Xna.Framework.Input.Keys.Q))
            {
                cheatForm.Show();
            }

            float freeMoney = cheatForm.InputtedMoney;
            if (freeMoney != 0)
            {
                Player.AddMoney(freeMoney);
                int[] adder = cheatForm.Adder;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < adder[i]; j++)
                    {
                        Inventory.AddItemToInventory(new Item((Item.Type)i, 1));
                    }
                }
                cheatForm.Hide();
                cheatForm = new Form1();
            }
        }
    }
}
