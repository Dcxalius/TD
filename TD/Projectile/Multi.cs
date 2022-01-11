using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class Multi : Projectile
    {

        public Multi(Vector2 aStartPosition, Monster aTarget, DamageMessage aDamageMessage) : base(aStartPosition,aTarget,aDamageMessage)
        {
            gfx = TextureManager.multiArrow;
            speed = 0.10f;
        }

    }
}
