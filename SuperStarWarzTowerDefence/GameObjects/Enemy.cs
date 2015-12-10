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
        int x = 0;
        Vector2 pos;
        Texture2D texture;
        SimplePath path;
        public Enemy(Texture2D texture, Vector2 pos, Game1 game) : base(texture, pos)
        {
            this.pos = pos;
            this.texture = texture;
            this.game = game;
            path = new SimplePath(game.GraphicsDevice);
        }

        public void Update()
        {
            x++;      
            pos = path.GetPos(path.beginT + x);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }
    }
}
