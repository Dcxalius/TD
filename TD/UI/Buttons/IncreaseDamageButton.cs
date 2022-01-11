using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class IncreaseDamageButton : SingleClickButton
    {
        protected TowerTemplate.AttackDataType dataType;
        public IncreaseDamageButton(Vector2 aPosition) : base(aPosition)
        {
            emblemGfx = TextureManager.damageButtonEmblem;
            dataType = TowerTemplate.AttackDataType.damage;
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
