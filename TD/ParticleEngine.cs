using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    static class ParticleEngine
    {
        public static List<Node> nodes = new List<Node>();

        public static void Update()
        {
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].Update();
            }
        }
        public static void Draw(SpriteBatch aBatch)
        {
            foreach (Node node in nodes)
            {
                node.Draw(aBatch);
            }
        }
    }

    class ParticleStartData
    {
        public Vector2 momentumOrientaion;
        public float momentumRange;

        public Vector2 velocityOrientation;
        public float velocityRange;

        public int size;

        public int shortestLife;
        public int lifeRange;

        public ParticleStartData(Vector2 aMomOr, float aMomentumRange, Vector2 aVelOr, float aVelocityRange, int aSize, int aMinLife, int aRange)
        {
            momentumOrientaion = aMomOr;
            momentumRange = aMomentumRange;
            velocityOrientation = aVelOr;
            velocityRange = aVelocityRange;
            size = aSize;
            shortestLife = aMinLife;                 
            lifeRange = aRange;
        }
    }

    class Node : GameObject
    {
        Particle[] particles;
        protected List<Color> colors = new List<Color>();
        protected ParticleStartData startData;
        int spawnsPerFrame;
        float decayChance;
        int framesRemaining;
        int spawnIndex = 0;

        public Node(int aSize, int aSpawnsPerFrame, float aDecayChance,int aDuration)
        {
            gfx = TextureManager.arrow;
            particles = new Particle[aSize];
            spawnsPerFrame = aSpawnsPerFrame;
            decayChance = aDecayChance;
            framesRemaining = aDuration;
            
        }

        public void UpdatePosition(Vector2 aPosition)
        {
            position = aPosition;
        }

        public void Update()
        {
            framesRemaining--;
            if (framesRemaining == 0)
            {
                ParticleEngine.nodes.Remove(this);
            }
            if (decayChance < RandomManager.random.NextDouble())
            {
                spawnsPerFrame--;
            }

            for (int i = 0; i < spawnsPerFrame; i++)
            {
                double momentomRandom = RandomManager.random.NextDouble() * startData.momentumRange * 2 * Math.PI;
                double velocityRandom = RandomManager.random.NextDouble() * startData.velocityRange * 2 * Math.PI;


                particles[spawnIndex] = new Particle(colors.ToArray(), position, 
                    new Vector2(
                        (float) (startData.momentumOrientaion.X * Math.Cos(momentomRandom) - startData.momentumOrientaion.Y * Math.Sin(momentomRandom)),
                        (float) (startData.momentumOrientaion.Y * Math.Sin(momentomRandom) + startData.momentumOrientaion.X * Math.Cos(momentomRandom))),
                    new Vector2(
                        (float)(startData.velocityOrientation.X * Math.Cos(momentomRandom) - startData.velocityOrientation.Y * Math.Sin(velocityRandom)),
                        (float)(startData.velocityOrientation.Y * Math.Sin(momentomRandom) + startData.velocityOrientation.X * Math.Cos(velocityRandom))),
                    startData.size,
                    startData.shortestLife + (int)(RandomManager.random.NextDouble() * startData.lifeRange)) ;

                spawnIndex++;
                if (spawnIndex >= particles.Length - 1)
                {
                    spawnIndex = 0;
                }
            }

            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i] != null)
                {
                    if (particles[i].framesRemaining == 0)
                    {
                        particles[i] = null;
                        continue;
                    }
                    particles[i].Update();
                }
            }
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i] != null)
                {
                    particles[i].Draw(aBatch);
                }
            }
        }
    }

    class RocketNode : Node
    {
        public RocketNode(Vector2 aPosition) : base(300, 20, 0.1f, 15)
        {
            position = aPosition;
            //drawRectangle
            startData = new ParticleStartData(new Vector2(0.3f, 0.3f), 1f, Vector2.One, 0f, 3, 7, 2);
            colors.Add(Color.Red);
            colors.Add(Color.Red);
            colors.Add(Color.Red);
            colors.Add(Color.Yellow);
            colors.Add(Color.White);
            colors.Add(Color.Gray);
        }
    }

    class FrostNode : Node
    {
        public FrostNode(Vector2 aPosition) : base(100, 2, 0f, 50)
        {
            position = aPosition;
            //drawRectangle
            startData = new ParticleStartData(new Vector2(0.3f, 0.3f), 1f, Vector2.One, 0f, 3, 7, 2);
            colors.Add(Color.Blue);
            colors.Add(Color.White);
            colors.Add(Color.BlueViolet);
            colors.Add(Color.Teal);
            colors.Add(Color.OldLace);
            colors.Add(Color.Gainsboro);
        }
    }
    
    class Particle : GameObject
    {
        Vector2 velocity;
        Vector2 momentum;
        public int framesRemaining;

        public Particle(Color[] aColors, Vector2 aPosition, Vector2 aVelocity, Vector2 aMomentum, int aSize, int aLifeSpan)
        {
            gfx = new Texture2D(GFXManager.graphicsDeviceManager.GraphicsDevice, aSize, aSize);
            Color[] colors = new Color[(int)Math.Pow(aSize, 2)];
            for (int i = 0; i < Math.Pow(aSize, 2); i++)
            {
                colors[i] = aColors[(int)(aColors.Length * RandomManager.random.NextDouble())];
            }
            gfx.SetData(colors);
            drawRectangle = new Rectangle(Point.Zero, new Point(aSize));
            position = aPosition;
            velocity = aVelocity;
            momentum = aMomentum;
            framesRemaining = aLifeSpan;
        }

        public void Update()
        {
            framesRemaining--;
            momentum += velocity;
            position += momentum;
            rotation = (float)(RandomManager.random.NextDouble() * Math.PI * 2);
        }

        public override void Draw(SpriteBatch aBatch)
        {
            base.Draw(aBatch);
        }
    }
}
