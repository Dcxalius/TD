using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class Basic : Projectile
    {

        public Basic(Vector2 aStartPosition, Monster aTarget, DamageMessage aDamageMessage) : base(aStartPosition, aTarget, aDamageMessage)
        {
            gfx = TextureManager.arrow;
            speed = 0.1f;
        }

    }
}
