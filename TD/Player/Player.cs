using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WinForm;

namespace TD
{
    static class Player
    {

       
        

        public static float money = Game1.StartMoney;


        public static bool CanBuy(float aAmount)
        {
            if (aAmount > money)
            {
                return false;
            }

            money -= aAmount;
            return true;
        }

        public static void AddMoney(float aAmount)
        {
            money += aAmount;
        }
    }
}
