using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class LevelUpButton : SingleClickButton
    {
        public LevelUpButton(Vector2 aPosition) : base(aPosition)
        {
            emblemGfx = TextureManager.levelUpEmblem;
        }

        override protected void Pressed()
        {
            Monster.LevelUp();
            framesSinceClick = 0;
            base.Pressed();
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
            DrawPrice(aBatch, (int) Monster.LevelPrice);
        }
    }
}
