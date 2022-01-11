using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class Rocket : Projectile
    {

        public Rocket(Vector2 aStartPosition, Monster aTarget, DamageMessage aDamageMessage) : base(aStartPosition,aTarget,aDamageMessage)
        {
            gfx = TextureManager.rocket;
            speed = 0.05f;
        }

    }
}
