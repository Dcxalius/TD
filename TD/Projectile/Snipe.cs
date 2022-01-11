using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class Snipe : Projectile
    {

        public Snipe(Vector2 aStartPosition, Monster aTarget, DamageMessage aDamageMessage) : base(aStartPosition,aTarget,aDamageMessage)
        {
            gfx = TextureManager.snipeArrow;
            speed = 0.15f;
        }

    }
}
