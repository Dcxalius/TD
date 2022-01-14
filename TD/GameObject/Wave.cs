using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using Spline;

namespace TD
{
    class Wave : Monster
    {
        const int GFXSize = 50;
        const int framesOfAnimation = 4;
        public Wave(SimplePath aPath) : base (aPath, new Point(GFXSize), framesOfAnimation)
        {

            gfx = TextureManager.wave;
            level = RandomManager.random.Next(1, 3) + LevelsBought;
            maxHealth = 15 + level * 10f;
            health = maxHealth;
            armor = 0f;
            money = 30 + level * 10;

            lootRank = 3;
        }
    }
}
