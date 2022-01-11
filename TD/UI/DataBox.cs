using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class DataBox : UIObject
    {
        Data data;
        

        public DataBox(Data aData, Vector2 aPosition)
        {
            gfx = TextureManager.dataBox;
            position = aPosition;
            offset = new Vector2(0, gfx.Height);
            gfxSize = gfx.Bounds.Size;
            drawRectangle = new Rectangle(Point.Zero, gfx.Bounds.Size);
            data = aData;
        }

        public void Update(Data aData)
        {
            data = aData;
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
            string dataToPrint = Math.Round(data.value, 6).ToString() + " " + data.suffix;
            Vector2 measuredString = TextureManager.font.MeasureString(dataToPrint);
            aBatch.DrawString(TextureManager.font, dataToPrint, new Vector2(position.X + gfxSize.X - 10 - measuredString.X, position.Y - gfxSize.Y + measuredString.Y / 2 - 3), Color.White);
        }
    }
}
