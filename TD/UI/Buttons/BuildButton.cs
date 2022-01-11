using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class BuildButton : Button
    {
        public BuildButton(Vector2 aPosition) : base(aPosition)
        {
            emblemGfx = TextureManager.towerButtonEmblem;
        }

        override protected void Pressed()
        {
            StateManager.currentState = StateManager.GameState.Build;
        }

        protected override void Released()
        {
            StateManager.currentState = StateManager.GameState.Game;
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
            Vector2 vector = TextureManager.font.MeasureString("If you read this you just lost the game!") / 2;
            vector.X = -TextureManager.unpressedButton.Width / 2 - 5;
            aBatch.DrawString(TextureManager.font, TowerTemplate.Price.ToString(), position - vector, Color.White);
        }
    }
}
