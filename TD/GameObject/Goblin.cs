using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using Spline;

namespace TD
{
    class Goblin : Monster
    {
        const int GFXSize = 50;
        const int framesOfAnimation = 4;
        public Goblin(SimplePath aPath) : base (aPath, new Point(GFXSize), framesOfAnimation)
        {

            gfx = TextureManager.goblin;
            level = RandomManager.random.Next(1, 4) + LevelsBought;
            maxHealth = 10 + level * 5f;
            health = maxHealth;
            armor = 0.10f;
            money = 3 + level * 2;

            lootRank = 1;
        }
    }
}
