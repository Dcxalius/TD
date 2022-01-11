using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    abstract class SingleClickButton : Button
    {
        protected int framesSinceClick = 8;

        protected SingleClickButton(Vector2 aPosition) : base(aPosition)
        {

        }

        override public void Update()
        {
            if (framesSinceClick < 8)
            {
                framesSinceClick++;

                if (framesSinceClick >= 8)
                {
                    status = Status.Released;
                }
            }
            else
            {
                base.Update();
            }
        }

        protected override void Pressed()
        {
            framesSinceClick = 0;
        }

        protected override void Released()
        {

        }

        protected void DrawPrice(SpriteBatch aBatch, int aPrice)
        {
            Vector2 vector = TextureManager.font.MeasureString("If you read this you just lost the game!") / 2;
            vector.X = -TextureManager.unpressedButton.Width / 2 - 5;
            aBatch.DrawString(TextureManager.font, aPrice.ToString(), position - vector, Color.White);
        }
    }
}
