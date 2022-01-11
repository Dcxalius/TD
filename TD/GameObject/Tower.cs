using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TD
{
    class Tower : TowerTemplate
    {
        public Tower(Vector2 aPosition)
        {
            gfx = TextureManager.baseTower;
            offset = gfx.Bounds.Size.ToVector2() / 2;
            position = aPosition;
            drawRectangle = new Rectangle(Point.Zero, gfx.Bounds.Size);
            hitRectangle = new Rectangle((aPosition - offset + new Vector2(GFXManager.GOROffsetX, GFXManager.GOROffsetY)).ToPoint(), gfx.Bounds.Size);
        }
    }
}
