using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    static class ProjectileManager
    {
        static List<Projectile> projectiles = new List<Projectile>();

        public static void AddProjectile(Vector2 aPosition, Monster aTarget, Projectile.DamageMessage aDamageMessage)
        {
            projectiles.Add(new Basic(aPosition, aTarget, aDamageMessage));
        }


        public static void AddProjectile(Vector2 aPosition, Monster aTarget, Projectile.DamageMessage aDamageMessage, Item.Type aTypeOfArrow)
        {
            switch (aTypeOfArrow)
            {
                case Item.Type.Rocket:
                    projectiles.Add(new Rocket(aPosition, aTarget, aDamageMessage));
                    break;
                case Item.Type.Freeze:
                    projectiles.Add(new Freeze(aPosition, aTarget, aDamageMessage));
                    break;
                case Item.Type.Snipe:
                    projectiles.Add(new Snipe(aPosition, aTarget, aDamageMessage));
                    break;
                case Item.Type.Count:
                    projectiles.Add(new Super(aPosition, aTarget, aDamageMessage));
                    break;
                default:
                    break;
            }
        }
        
        public static void Update()
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update();
                if (projectiles[i].IsFinished == true)
                {
                    projectiles.RemoveAt(i);
                }
            }
        }

        public static void Draw(SpriteBatch aBatch)
        {
            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(aBatch);
            }
        }
    }
}
