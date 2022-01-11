using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class Freeze : Projectile
    {

        public Freeze(Vector2 aStartPosition, Monster aTarget, DamageMessage aDamageMessage) : base(aStartPosition,aTarget,aDamageMessage)
        {
            gfx = TextureManager.freezeArrow;
            speed = 0.05f;
        }

    }
}
