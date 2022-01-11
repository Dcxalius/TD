using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TD
{
    public class Game1 : Game
    {
        public const int StartMoney = 150;
        public const bool Cheats = true;

        public static Game1 self;

        public Game1()
        {
            self = this;
            GraphicsDeviceManager graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            GFXManager.Init(graphicsDeviceManager);
        }
        protected override void Initialize()
        {
            Inventory.Init();
            MonsterManager.InitPath();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            TextureManager.LoadTex(Content);
        }
        protected override void Update(GameTime gameTime)
        {
            Data.UpdateGameTime(gameTime);
            StateManager.Update();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            StateManager.Draw();
            GFXManager.Draw();
            base.Draw(gameTime);
        }
    }
}
