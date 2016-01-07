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
        
        float currentpos;
        Vector2 followPath;
        public Rectangle hitbox;
        public bool alive = true;
        SimplePath path;
        public Enemy(Texture2D texture, Game1 game, SimplePath path) : base(texture, Vector2.Zero,new Vector2(texture.Width / 2, texture.Height / 2))
        {
            this.pos = path.GetPos(path.endT);
            this.texture = texture;
            this.game = game;
            this.path = path;
            currentpos = path.beginT;
            followPath = path.GetPos(currentpos + 0.1f) - path.GetPos(currentpos);
        }

        public override void Update()
        {

            currentpos += speed;
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }

        public Vector2 GetPos()
        {
            return path.GetPos(currentpos);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, path.GetPos(currentpos), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, Offset, 1f, SpriteEffects.None, 1f);
            spriteBatch.Draw(GameHandler.test, hitbox, Color.Red);
        }
    }
    
}
