using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spline;

namespace SuperStarWarzTowerDefence.GameObjects
{
    class Enemy : GameObject
    {
        Game1 game;
        int speed = 2;
        float pos;

        Texture2D texture;
        SimplePath path;
        public Enemy(Texture2D texture, Game1 game, SimplePath path) : base(texture, Vector2.Zero)
        {
            this.pos = path.beginT;
            this.texture = texture;
            this.game = game;
            this.path = path;
        }

        public void Update()
        {
                  
            pos += speed;
        }

        public Vector2 GetPos()
        {
            return path.GetPos(pos);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, path.GetPos(pos), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 1f);
        }
    }
    
}
