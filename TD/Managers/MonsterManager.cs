using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;
using Spline;
using Microsoft.Xna.Framework.Graphics;

namespace TD
{
    static class MonsterManager
    {
        static List<Monster> monsters = new List<Monster>();
        static SimplePath simplePath = new SimplePath(GFXManager.graphicsDeviceManager.GraphicsDevice);
        static int framesBetweenSpawn = 60 * 3;
        static int framesSinceLastSpawn = framesBetweenSpawn;

        public static void InitPath()
        {
            while (simplePath.AntalPunkter != 1)
            {
                simplePath.RemovePoint(0);
            }
            simplePath.SetPos(0, new Vector2(0, 270));
            simplePath.AddPoint(new Vector2(150, 430));
            simplePath.AddPoint(new Vector2(830, 430));
            simplePath.AddPoint(new Vector2(120, 130));
            simplePath.AddPoint(new Vector2(780, 120));
            simplePath.AddPoint(new Vector2(980, 270));
        }

        public static void DEBUGPrintPath(SpriteBatch aBatch)
        {
            simplePath.Draw(aBatch);
            simplePath.DrawPoints(aBatch);
        }

        public static void Update()
        {
            framesSinceLastSpawn++;

            if (framesSinceLastSpawn >= framesBetweenSpawn)
            {
                framesSinceLastSpawn = 0;
                monsters.Add(new Goblin(simplePath));
            }

            for (int i = monsters.Count - 1; i >= 0; i--)
            {
                monsters[i].Update();

                if (monsters[i].IsAlive == false)
                {
                    Player.AddMoney(monsters[i].Money);
                    monsters.RemoveAt(i);
                }
            }
        }

        public static void Draw(SpriteBatch aBatch)
        {
            foreach (Monster monster in monsters)
            {
                monster.Draw(aBatch);
            }

        }

        public static void DrawStatusBars(SpriteBatch aBatch)
        {
            foreach (Monster monster in monsters)
            {
                monster.DrawStatusBar(aBatch);
            }
        }

        public static Monster GetFurthestMonsterInRangeOfPosition(Vector2 aPosition, float aRange)
        {
            Monster currentClosestMonster = null;
            foreach (Monster monster in monsters)
            {
                if (Math.Sqrt(Math.Pow(monster.Position.X - aPosition.X,2)  + Math.Pow(monster.Position.Y - aPosition.Y, 2)) < aRange)
                {
                    if (currentClosestMonster != null)
                    {
                        if (currentClosestMonster.Progress < monster.Progress)
                        {
                            currentClosestMonster = monster;
                        }
                    }
                    else
                    {
                        currentClosestMonster = monster;
                    }
                }
            }

            if (currentClosestMonster != null)
            {
                return currentClosestMonster;

            }
            else
            {
                return null;
            }
        }

        public static List<Monster> GetMonstersInSplash(Vector2 aPosition, float aSplash)
        {
            List<Monster> list = new List<Monster>();

            foreach (Monster monster in monsters)
            {
                if (Math.Sqrt(Math.Pow(monster.Position.X - aPosition.X, 2) + Math.Pow(monster.Position.Y - aPosition.Y, 2)) < aSplash)
                {
                    list.Add(monster);
                }
            }

            return list;
        }
    }
}
