using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class MovingObject : GameObject
    {

        protected Vector2 oldPosition;
        protected float progress = 0f;
        protected float speed = 0.5f;


        public float Progress
        {
            get => progress;
        }

        public virtual void Update(Vector2 aPosition)
        {
            oldPosition = position;
            position = aPosition;

            rotation = (float)Math.Atan2((oldPosition - position).Y, (oldPosition - position).X);
        }
    }
}
