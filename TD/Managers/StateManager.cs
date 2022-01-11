using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TD
{
    static class StateManager
    {
        public enum GameState
        {
            Menu,
            Game,
            Build,
            EndScreen
        }

        public static GameState currentState = GameState.Game;

        public static void Initialize()
        {

        }

        public static void Update()
        {
            InputManager.Update();
            UI.Update();

            switch (currentState)
            {
                case GameState.Menu:
                    break;
                case GameState.Build:
                    TowerManager.BuildUpdate();
                    UpdateBuildAndGame();
                    break;
                case GameState.Game:
                    TowerManager.GameUpdate();
                    UpdateBuildAndGame();
                    break;
                case GameState.EndScreen:
                    break;
                default:
                    break;
            }
        }

        static void UpdateBuildAndGame()
        {
            ProjectileManager.Update();
            TowerManager.Update();
            MonsterManager.Update();
            Inventory.Update();
            ParticleEngine.Update();

            if (Game1.Cheats == true)
            {
                CheatEngine.Update();

            }

        }

        public static void Draw()
        {
           

            switch (currentState)
            {
                case GameState.Menu:
                    break;
                case GameState.Build:
                    DrawBuildAndGame();
                    break;
                case GameState.Game:
                    DrawBuildAndGame();
                    break;
                case GameState.EndScreen:
                    break;
                default:
                    break;
            }
        }

        static void DrawBuildAndGame()
        {
            GFXManager.DrawOverlay();
            GFXManager.DrawGameObjectsToGameObjectRenderer();
            GFXManager.DrawMovingObjectsToMovingObjectRenderer();
        }
    }
}