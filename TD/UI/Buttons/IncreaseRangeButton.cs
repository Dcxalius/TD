using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class IncreaseRangeButton : SingleClickButton
    {
        protected TowerTemplate.AttackDataType dataType;
        public IncreaseRangeButton(Vector2 aPosition) : base(aPosition)
        {
            emblemGfx = TextureManager.rangeButtonEmblem;
            dataType = TowerTemplate.AttackDataType.range;
        }

        protected override void Pressed()
        {
            UI.targetTower.IncreaseData(dataType);
            UI.UpdateBox(dataType);
            base.Pressed();
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
            DrawPrice(aBatch, UI.targetTower.AttackData[(int)dataType].price);
        }
    }
}
