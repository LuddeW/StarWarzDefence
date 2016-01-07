using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence.GameObjects
{
    class Shot:GameObject
    {
        Vector2 speed = new Vector2(5,5);
        Vector2 direction;
        public Rectangle hitbox;
        Enemy target;
        float timeToLive = 1f;
        public bool alive = true;
        public Shot(Texture2D texture, Vector2 pos, Enemy target) : base(texture, pos, new Vector2(0,0))
        {
            this.target = target;
        }

        public override void Update()
        {
            direction = target.GetPos() - pos;
            direction.Normalize();
            pos += direction * speed;
            hitbox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }

    }
}
