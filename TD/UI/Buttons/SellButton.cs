using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class SellButton : SingleClickButton
    {
        Item.Type dataType;
        public SellButton(Vector2 aPosition) : base(aPosition)
        {
            //emblemGfx = TextureManager.towerButtonEmblem;
        }

        override protected void Pressed()
        {
            Player.AddMoney(UI.targetItem.ItemData[(int)UI.targetItem.GetAnyActive].price);
            Inventory.RemoveItem(UI.targetItem);
            framesSinceClick = 0;
            base.Pressed();
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
            DrawPrice(aBatch, UI.targetItem.ItemData[(int)UI.targetItem.GetAnyActive].price);
        }
    }
}
