using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class MergeButton : Button
    {
        public MergeButton(Vector2 aPosition) : base(aPosition)
        {
            emblemGfx = TextureManager.towerButtonEmblem;
        }

        override protected void Pressed()
        {
            Inventory.mergeSwitch = true;
        }

        protected override void Released()
        {
            Inventory.mergeSwitch = false;
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
            Vector2 vector = TextureManager.font.MeasureString("If you read this you just lost the game!") / 2;
            vector.X = -TextureManager.unpressedButton.Width / 2 - 5;
            aBatch.DrawString(TextureManager.font, UI.targetItem.Rank.ToString(), position - vector, Color.White);
        }
    }
}
