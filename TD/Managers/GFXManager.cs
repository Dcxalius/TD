using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD
{
    static class GFXManager
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static SpriteBatch mainBatch;

        public const int ScreenWidth = 1280;
        public const int ScreenHeight = 720;

        static RenderTarget2D overlayRenderer;
        static RenderTarget2D gameObjectRenderer;
        static RenderTarget2D movingObjectRenderer;
        public const int GOROffsetX = 100;
        public const int GOROffsetY = 100;
        public const int GORSizeX = 980;
        public const int GORSizeY = 520;
        public static Vector2 GOROffset = new Vector2(GOROffsetX, GOROffsetY);
        static RenderTarget2D toolbarRenderer;
        public const int UIROffsetX = 1080;

        public static void Init(GraphicsDeviceManager aGraphicsDeviceManager)
        {
            graphicsDeviceManager = aGraphicsDeviceManager;
            graphicsDeviceManager.PreferredBackBufferWidth = 1280;
            graphicsDeviceManager.PreferredBackBufferHeight = 720;
            graphicsDeviceManager.ApplyChanges();

            mainBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            toolbarRenderer = new RenderTarget2D(graphicsDeviceManager.GraphicsDevice, 200, 720);
            overlayRenderer = new RenderTarget2D(graphicsDeviceManager.GraphicsDevice, ScreenWidth, ScreenHeight);

            gameObjectRenderer = new RenderTarget2D(graphicsDeviceManager.GraphicsDevice, GORSizeX, GORSizeY);
            movingObjectRenderer = new RenderTarget2D(graphicsDeviceManager.GraphicsDevice, GORSizeX, GORSizeY);
        }

        public static void DrawOverlay()
        {
            SpriteBatch batch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(overlayRenderer);

            batch.Begin();

            graphicsDeviceManager.GraphicsDevice.Clear(Color.Transparent);
            if (StateManager.currentState == StateManager.GameState.Build)
            {
                batch.Draw(TextureManager.buildTower, new Rectangle(InputManager.MousePosition - TextureManager.buildTower.Bounds.Size / new Point(2), TextureManager.buildTower.Bounds.Size), Color.White);
            }
            MonsterManager.DrawStatusBars(batch);

            batch.End();

            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);
        }

        public static void DrawGameObjectsToGameObjectRenderer()
        {
            SpriteBatch batch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(gameObjectRenderer);

            batch.Begin();

            graphicsDeviceManager.GraphicsDevice.Clear(Color.Transparent);

            batch.Draw(TextureManager.road, new Vector2(0, 0), Color.White);
            if (StateManager.currentState == StateManager.GameState.Game && UI.targetTower != null)
            {
                batch.Draw(TextureManager.selectedTower, UI.targetTower.Position, null, Color.White, 0f, TextureManager.selectedTower.Bounds.Size.ToVector2() / 2, UI.targetTower.AttackData[(int)TowerTemplate.AttackDataType.range].value / (TextureManager.selectedTower.Width / 2), SpriteEffects.None, 1f);
            }

            TowerManager.Draw(batch);

            batch.End();

            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);
        }

        public static void DrawMovingObjectsToMovingObjectRenderer()
        {
            SpriteBatch batch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(movingObjectRenderer);

            batch.Begin();

            graphicsDeviceManager.GraphicsDevice.Clear(Color.Transparent);


            //MonsterManager.DEBUGPrintPath(batch);
            MonsterManager.Draw(batch);
            ProjectileManager.Draw(batch);



            batch.End();

            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);
        }

        public static bool CanPlace(Point aPoint)
        {
            Texture2D texture = TextureManager.buildTower;

            Color[] pixels = new Color[texture.Width * texture.Height];
            Color[] pixels2 = new Color[texture.Width * texture.Height];

            texture.GetData<Color>(pixels2);
            gameObjectRenderer.GetData(0, new Rectangle(aPoint, texture.Bounds.Size), pixels, 0, pixels.Length);

            for (int i = 0; i < pixels.Length; ++i)
            {
                if (pixels[i].A > 0.0f && pixels2[i].A > 0.0f)
                    return false;
            }

            

            return true;
        }


        public static void DrawUIToUIRenderer(UIObject[] aUIObjects) //TODO: Remake if time
        {
            SpriteBatch batch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(toolbarRenderer);
            batch.Begin();

            graphicsDeviceManager.GraphicsDevice.Clear(Color.Transparent);
            batch.Draw(TextureManager.uiBackground, Vector2.Zero, Color.White);
            batch.Draw(TextureManager.coinPurse, Vector2.Zero, Color.White);
            batch.Draw(TextureManager.itemSlots, new Vector2(0, 140), Color.White);
            Inventory.Draw(batch);
            batch.DrawString(TextureManager.font, Player.money.ToString(), new Vector2(70, 30), Color.White);

            foreach (UIObject uIObject in aUIObjects)
            {
                uIObject.Draw(batch);
            }


            batch.End();

            graphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);
        }

        public static void Draw()
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);

            mainBatch.Begin();

            mainBatch.Draw(TextureManager.background, Vector2.Zero, Color.White);
            mainBatch.Draw(TextureManager.gORBackground, GOROffset, Color.White);
            mainBatch.Draw(gameObjectRenderer, GOROffset, Color.White);
            mainBatch.Draw(movingObjectRenderer, GOROffset, Color.White);
            mainBatch.Draw(overlayRenderer, Vector2.Zero, Color.White);
            mainBatch.Draw(TextureManager.foreground, new Vector2(0, ScreenHeight - TextureManager.foreground.Bounds.Height), Color.White);
            mainBatch.Draw(toolbarRenderer, new Vector2(UIROffsetX, 0), Color.White);
            UI.Draw(mainBatch);
            mainBatch.End();

        }


    }
}
