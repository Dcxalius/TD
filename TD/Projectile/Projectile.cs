using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    class Projectile : MovingObject
    {
        public struct DamageMessage
        {
            public float damage;
            public float[] type;

            public DamageMessage(float aAmount, float[] aTypes)
            {
                damage = aAmount;
                type = aTypes;
            }

            
        }

        protected DamageMessage currentMessage;


        protected Vector2 startPosition;
        protected Vector2 targetPosition;
        protected Vector2 lastKnownPosition;
        protected Monster targetMonster;
        protected bool journeyComplete = false;

        public bool IsFinished
        {
            get
            {
                if (journeyComplete == true)
                {
                    if (currentMessage.type[(int)Item.Type.Rocket] > 0)
                    {
                        ParticleEngine.nodes.Add(new RocketNode(position));
                        foreach (Monster monster in MonsterManager.GetMonstersInSplash(targetPosition, currentMessage.type[(int)Item.Type.Rocket]))
                        {
                            monster.AddDamageMessage(currentMessage);
                        }
                    }
                    else
                    {
                        if (targetMonster != null)
                        {
                            targetMonster.AddDamageMessage(currentMessage);
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Projectile(Vector2 aStartPosition, Monster aTarget, DamageMessage aDamageMessage)
        {
            gfx = TextureManager.arrow;
            drawRectangle = new Rectangle(Point.Zero, gfx.Bounds.Size);
            currentMessage = aDamageMessage;
            startPosition = aStartPosition;
            position = aStartPosition;
            targetMonster = aTarget;
            targetPosition = targetMonster.Position;
            lastKnownPosition = targetPosition;
            progress = 0;
            rotation = (float)Math.Atan2((targetPosition - position).Y, (targetPosition - position).X);
        }

        public void Update()
        {
            progress += speed;
            if (progress >= 1f)
            {
                journeyComplete = true;
            }

            if (targetMonster == null)
            {
                targetPosition = lastKnownPosition;
            }
            else
            {
                targetPosition = targetMonster.Position;
            }

            base.Update(startPosition + (targetPosition - startPosition) * progress);
        }
    }
}
