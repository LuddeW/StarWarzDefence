using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence
{
    public class Emitter
    {
        private Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> particles;
        private List<Texture2D> textures;

        public Emitter(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            // Vector2 velocity = new Vector2(1f * (float)(random.NextDouble() * 2 - 1), 1f * (float)(random.NextDouble() * 2 - 1));
            Vector2 velocity = new Vector2((float)random.NextDouble(), -1f * (float)random.NextDouble());
            //float angle = MathHelper.ToDegrees(3.14f);
            //float angularVelocity = 5f;
            int ttl = 20 + random.Next(40);

            int red = (byte)random.Next(45, 60);
            int green = (byte)random.Next(200, 215);
            int blue = (byte)random.Next(240, 255);
            Color color = new Color(red, green, blue)* 0.3f;                   
            float size = (float)random.NextDouble();
            float layerDepth = (float)random.NextDouble();
            return new Particle(texture, position, velocity, 0f, 0f, color, 3f, ttl, layerDepth);
        }

        public void Update()
        {
            int total = 10;

            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch);
            }
            
        }

    }
}
