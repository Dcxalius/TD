using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    abstract class Button : UIObject
    {
        protected enum Status
        {
            Pressed,
            Released
        }

        protected Texture2D emblemGfx;
        Texture2D pressedGfx;
        protected Status status;
        public Button(Vector2 aPosition)
        {
            gfx = TextureManager.unpressedButton;
            pressedGfx = TextureManager.pressedButton;
            position = aPosition;
            offset = gfx.Bounds.Size.ToVector2() / 2;
            drawRectangle = new Rectangle(Point.Zero, gfx.Bounds.Size);
            status = Status.Released;
            hitRectangle = new Rectangle((aPosition - offset + new Vector2(GFXManager.UIROffsetX, 0)).ToPoint(), gfx.Bounds.Size);
        }

        public override void Draw(SpriteBatch aBatch)
        {
            if (status == Status.Released)
            {
                base.Draw(aBatch);
                if (emblemGfx != null)
                {
                    aBatch.Draw(emblemGfx, position, null, color, rotation, emblemGfx.Bounds.Size.ToVector2() / 2, scale, SpriteEffects.None, 1f);
                }
            }
            else
            {
                aBatch.Draw(pressedGfx, position, drawRectangle, color, rotation, offset, scale, SpriteEffects.None, 1f);
            }
        }

        public virtual void Update()
        {
            if (InputManager.SingleLeftClick(hitRectangle))
            {
                switch (status)
                {
                    case Status.Pressed:
                        Released();
                        status = Status.Released;
                        break;
                    case Status.Released:
                        Pressed();
                        status = Status.Pressed;
                        break;
                    default:
                        break;
                }
            }
        }

        abstract protected void Pressed();
        abstract protected void Released();
    }
}
