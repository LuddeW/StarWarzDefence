﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence
{
    public class Particle
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Angle { get; set; }
        public float AngleVelocity { get; set; }
        public Color Color { get; set; }
        public float Size { get; set; }
        public int TTL { get; set; }
        public float LayerDepth { get; set; }

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, float angle, float angleVelocity, Color color, float size, int ttl, float layerDepth)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
            AngleVelocity = angleVelocity;
            Color = color;
            Size = size;
            TTL = ttl;
            LayerDepth = layerDepth;
        }

        public void Update()
        {
            TTL--;
            Position += Velocity;
            Angle += AngleVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color, Angle, origin, Size, SpriteEffects.None, LayerDepth);
            
        }
    }
}
