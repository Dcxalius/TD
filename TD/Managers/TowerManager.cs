using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Microsoft.Xna.Framework;
using Spline;

namespace TD
{
    static class TowerManager
    {
        static List<TowerTemplate> towers = new List<TowerTemplate>();

        public static List<TowerTemplate> Towers
        {
            get => towers;
        }

        public static void Draw(SpriteBatch aBatch)
        {
            foreach (TowerTemplate tower in towers)
            {
                tower.Draw(aBatch);
            }
        }

        public static void Update()
        {
            foreach (TowerTemplate tower in towers)
            {
                tower.Update();
            }
        }

        public static void BuildUpdate()
        {
            if (InputManager.SingleLeftClick(new Rectangle(GFXManager.GOROffsetX + Tower.Size / 2, GFXManager.GOROffsetY + Tower.Size / 2, GFXManager.GORSizeX - Tower.Size, GFXManager.GORSizeY - Tower.Size)))
            {
                Point mousePositionAdjusted = InputManager.MousePosition - new Point(TowerTemplate.Size / 2);

                if (GFXManager.CanPlace(mousePositionAdjusted - new Point(GFXManager.GOROffsetX, GFXManager.GOROffsetY)))
                {
                    if (Player.CanBuy(TowerTemplate.Price))
                    {
                        towers.Add(new Tower((InputManager.MousePosition - new Point(GFXManager.GOROffsetX, GFXManager.GOROffsetY)).ToVector2()));

                    }
                }
            }
        }

        public static void GameUpdate()
        {
            if (InputManager.SingleLeftClick(new Rectangle(GFXManager.GOROffsetX, GFXManager.GOROffsetY, GFXManager.GORSizeX, GFXManager.GORSizeY)))
            {
                UI.ClearTargets();
                foreach (TowerTemplate tower in towers)
                {
                    if (InputManager.SingleLeftClick(tower.HitRectangle))
                    {
                        UI.TargetNewTower(tower);
                    }
                }
            }
        }
    }
}
