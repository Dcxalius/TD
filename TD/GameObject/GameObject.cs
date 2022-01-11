using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    abstract class GameObject
    {
        protected Texture2D gfx;
        protected Vector2 position = Vector2.Zero;
        protected Point gfxSize = Point.Zero;
        protected Rectangle drawRectangle = Rectangle.Empty;
        protected Color color = Color.White;
        protected float rotation = 0f;
        protected Vector2 offset = Vector2.Zero;
        protected float scale = 1f;
        protected Rectangle hitRectangle = Rectangle.Empty;

        public Rectangle HitRectangle
        {
            get => hitRectangle;
        }

        public Vector2 Position
        {
            get => position;
        }

        public Vector2 Offset
        {
            get => offset;
        }
        public Point GfxSize
        {
            get => gfxSize;
        }

        public virtual void Draw(SpriteBatch aBatch)
        {
            aBatch.Draw(gfx, position, drawRectangle, color, rotation, offset, scale, SpriteEffects.None, 1f);
        }
    }
}
