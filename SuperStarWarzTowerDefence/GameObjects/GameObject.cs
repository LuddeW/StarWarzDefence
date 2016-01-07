using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence.GameObjects
{
    class GameObject
    {
        public Texture2D texture;
        protected Vector2 pos;
        Rectangle hitbox;
        private Vector2 offset;
        Color[] texData;

        public GameObject(Texture2D texture, Vector2 pos, Vector2 offset)
        {
            this.texture = texture;
            this.pos = pos;
            this.Offset = offset;
            hitbox = new Rectangle((int)(pos.X + offset.X),(int)(pos.Y + offset.Y), texture.Width, texture.Height);
            texData = new Color[texture.Width * texture.Height];
            texture.GetData(texData);
        }
        public Vector2 Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }

        public virtual void Update()
        {
            hitbox = new Rectangle((int)(pos.X + offset.X), (int)(pos.Y + offset.Y), texture.Width, texture.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }

        public bool PixelCollition(Color[] collisionData, Rectangle collisionHitbox)
        {
            //int top = Math.Max(hitbox.Top, collisionHitbox.Top);
            //int bottom = Math.Min(hitbox.Bottom, collisionHitbox.Bottom);
            //int left = Math.Max(hitbox.Left, collisionHitbox.Left);
            //int right = Math.Min(hitbox.Right, collisionHitbox.Right);

            for (int i = 0; i < collisionData.Length; i++)
            {
                if (collisionData[i].A > 0.0f && texData[i].A > 0.0f)
                {
                    return true;
                }
            }

            //for (int y = top; y < bottom; y++)
            //{
            //    for (int x = left; x < right; x++)
            //    {
            //        Color colorA = texData[texture.Width * (y - hitbox.Y) + x - hitbox.X];
            //        int index = collisionHitbox.Width * (y - collisionHitbox.Y) + x - collisionHitbox.X;
            //        Color colorB = collisionData[index];
            //        if (colorA.A + colorB.A > 256)
            //        {
            //            return true;
            //        }
            //    }
            //}
            return false;
        }

        public Texture2D CreateCircle(int radius,Color color)
        {
            int outerRadius = radius * 2 + 2; 
            Texture2D texture = new Texture2D(GameHandler.game.GraphicsDevice, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];


            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            double angleStep = 1f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));
             
                data[y * outerRadius + x + 1] = color;              
            }

            texture.SetData(data);
            return texture;
        }
    }
}
