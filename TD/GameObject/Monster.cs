using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using Spline;
using System.Diagnostics;

namespace TD
{
   
    abstract class Monster : MovingObject
    {
        static private int levelsBought = 0;
        static public int LevelsBought
        {
            get => levelsBought;
        }
        static private float levelPrice = 50;
        static public float LevelPrice
        {
            get => levelPrice;
        }

        static public void LevelUp()
        {
            if (Player.CanBuy(levelPrice) == false)
            {
                return;
            }
            levelsBought++;
            levelPrice *= 2f;
        }

        protected SimplePath path;
        
        protected float maxHealth;
        protected float health;
        private float uArmor;
        protected int level;
        protected int lootRank;
        protected float money;

        List<Projectile.DamageMessage> damageMessages = new List<Projectile.DamageMessage>();
        List<int> frostStacks = new List<int>(50);

        


        const int healthBarFullSize = 49;
        Rectangle healthBarGfxRectangle = new Rectangle(0, 0, healthBarFullSize, TextureManager.healthbar.Height);
        int currentAnimationFrame = 0;
        protected int framesInAnimation;
        protected Rectangle[] animationDrawRectangles;
        int framesSinceChange = 0;
        const int framesBetweenChange = 10;
        protected float armor
        {
            get => uArmor;
            set
            {
                if (value < 0 || value > 1)
                {
                    Debug.Assert(false, "uArmor was attempted to be set to invalid values");
                }
                uArmor = value;
            }
        }
        

        public bool IsAlive
        {
            get
            {
                if (health > 0)
                {
                    return true;
                }

                if (RandomManager.random.NextDouble() > 0.2 * Math.Log10(level))
                {
                    if (Inventory.AddItemToInventory(new Item((Item.Type)RandomManager.random.Next(0, (int)Item.Type.Count), RandomManager.random.Next(Math.Max(1, lootRank - 4), lootRank + 1))))
                    {
                        //TODO: Add item to world prehaps
                    }
                }
                
                return false;
            }
        }

        public float Money
        {
            get => money;
        }

        public Monster(SimplePath aPath, Point aSize, int aAnimationDuration)
        {
            framesInAnimation = aAnimationDuration;
            animationDrawRectangles = new Rectangle[framesInAnimation];
            
            path = aPath;
            gfxSize = aSize;
            offset = gfxSize.ToVector2() / 2;
            progress = path.beginT;
            position = path.GetPos(progress);
            for (int i = 0; i < framesInAnimation; i++)
            {
                animationDrawRectangles[i] = new Rectangle(i * gfxSize.X, 0, gfxSize.X, gfxSize.Y);
            }
            drawRectangle = animationDrawRectangles[0];
            //hitRectangle = new Rectangle((aPosition - offset + new Vector2(GFXManager.GOROffsetX, GFXManager.GOROffsetY)).ToPoint(), gfx.Bounds.Size);
        }



        public void Update()
        {
            while (damageMessages.Count != 0 && IsAlive)
            {
                if (RandomManager.random.NextDouble() < 0.3)
                {
                    health -= damageMessages[0].damage * 2 + damageMessages[0].type[(int)Item.Type.Snipe];
                }
                else
                {
                    health -= damageMessages[0].damage * (1 - armor);
                }

                if (damageMessages[0].type[(int)Item.Type.Freeze] > 0)
                {
                    AddFrostStack((int) (damageMessages[0].type[(int)Item.Type.Freeze] / Data.gameTime.ElapsedGameTime.TotalSeconds));

                }
                damageMessages.RemoveAt(0);
            }

            healthBarGfxRectangle.Width = (int)(healthBarFullSize * health / maxHealth);

            framesSinceChange++;

            if (framesSinceChange >= framesBetweenChange)          
            {
                framesSinceChange = 0;
                currentAnimationFrame++;
                if (currentAnimationFrame >= framesInAnimation)
                {
                    currentAnimationFrame = 0;
                }

                drawRectangle = animationDrawRectangles[currentAnimationFrame];
            }

            progress += speed * ConsumeFrostStack();
            if (progress >= path.endT)
            {
                Game1.self.Exit();
            }
            
            
            base.Update(path.GetPos(progress));
        }

        public void AddDamageMessage(Projectile.DamageMessage aDamageMessage)
        {
            damageMessages.Add(aDamageMessage);
        }

        void AddFrostStack(int aDurationInFrames)
        {
            if (frostStacks.Count == frostStacks.Capacity)
            {
                frostStacks.Sort();
                if (frostStacks[frostStacks.Capacity - 1] < aDurationInFrames)
                {
                    frostStacks[frostStacks.Capacity - 1] = aDurationInFrames;
                }
            }
            else
            {
                frostStacks.Add(aDurationInFrames);
            }
        }

        float ConsumeFrostStack()
        {
            int count = frostStacks.Count;
            for (int i = frostStacks.Count - 1; i >= 0; i--)
            {
                frostStacks[i]--;
                if (frostStacks[i] <= 0)
                {
                    frostStacks.RemoveAt(i);
                }
            }

            if (frostStacks.Count != 0)
            {
                for (int i = 0; i < Math.Ceiling(frostStacks.Count / 10f); i++)
                {
                    ParticleEngine.nodes.Add(new FrostNode(position));
                }
            }
            return 1f - count / 100f;
        }

        public void DrawStatusBar(SpriteBatch aBatch)
        {
            Vector2 tempPosition = position - new Vector2(0, gfxSize.Y)/ 2 + GFXManager.GOROffset;
            Texture2D tempTexture = TextureManager.statusbar;
            aBatch.Draw(tempTexture, tempPosition, null, Color.White, 0f, new Vector2(tempTexture.Width / 2, tempTexture.Height), 1f, SpriteEffects.None, 1f);
            aBatch.Draw(TextureManager.healthbar, tempPosition, healthBarGfxRectangle, Color.White, 0f, new Vector2(tempTexture.Width / 2, tempTexture.Height), 1f, SpriteEffects.None, 1f);

            Point numberSize = new Point(7, 12);
            for (int i = 0; i < Math.Ceiling(Math.Log10(level+1)) ; i++)
            {
                int number = (int)((level / (int)Math.Pow(10, i) * (int)Math.Pow(10, i) - level / (int)Math.Pow(10, i + 1) * (int)Math.Pow(10, i + 1)) / Math.Pow(10, i));
                aBatch.Draw(TextureManager.statusbarNumbers, new Vector2(tempPosition.X + gfxSize.X / 2 - numberSize.X * 2 - (i - (int)Math.Ceiling(Math.Log10(level + 1))) * (numberSize.X + 1), tempPosition.Y - tempTexture.Height), new Rectangle(number % 5 * numberSize.X, (int)Math.Floor(number / 5d) * numberSize.Y, numberSize.X, numberSize.Y), Color.White);
            }
        }
            
    }
}
