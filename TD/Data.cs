using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    public class Data
    {
        public int price;
        public float baseValue;
        public float value;
        public float increment;
        public string suffix;

        public Data(int aPrice, float aValue, float aIncrement, string aString)
        {
            price = aPrice;
            baseValue = aValue;
            value = aValue;
            increment = aIncrement;
            suffix = aString;
        }

        public void RefreshItemData(int anAmount, int aRank)
        {
            price = 50 * (int) Math.Pow(aRank,2);
            if (anAmount <= 0)
            {
                value = 0;
                return;
            }
            value = baseValue + anAmount * increment;
        }

        public bool IncreaseData()
        {
            if (Player.CanBuy(price) == false)
            {
                return false;
            }
            
            value += increment;
            price = (int)(price * 1.6f);

            return true;
        }

        public static GameTime gameTime;

        public static void UpdateGameTime(GameTime aGameTime)
        {
            gameTime = aGameTime;
        }
    }
}
