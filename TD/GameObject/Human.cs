using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using Spline;

namespace TD
{
    class Human : Monster
    {
        const int GFXSize = 50;
        const int framesOfAnimation = 4;
        public Human(SimplePath aPath) : base (aPath, new Point(GFXSize), framesOfAnimation)
        {

            gfx = TextureManager.human;
            level = RandomManager.random.Next(2, 5) + LevelsBought;
            maxHealth = 8 + level * 5f;
            health = maxHealth;
            armor = 0.10f;
            money = 3 + level * 2;

            lootRank = 2;
        }
    }
}
