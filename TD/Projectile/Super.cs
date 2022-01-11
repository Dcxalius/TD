using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class Super : Projectile
    {

        public Super(Vector2 aStartPosition, Monster aTarget, DamageMessage aDamageMessage) : base(aStartPosition, aTarget, aDamageMessage)
        {
            gfx = TextureManager.superArrow;
            speed = 0.5f;
        }

    }
}
