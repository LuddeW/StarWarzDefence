using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperStarWarzTowerDefence.GameObjects.Tower
{
    class Tower : GameObject
    {
        protected Vector2 pos;
        public Texture2D texture;
        bool isAactive = false;
        protected int range;
        protected float fireSpeed = 1f;
        Texture2D circle;
        public Tower(Texture2D texture, Vector2 pos, int range) :base(texture, pos)
        {
            this.pos = pos;
            this.texture = texture;
            this.range = range;
            circle = CreateCircle(range);
        }

        public Vector2 Pos {  get {return pos;} internal set { pos = value; }}
        public void Activate()
        {
            isAactive = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAactive == false)
            {
                spriteBatch.Draw(circle, pos, new Rectangle(0, 0, circle.Width, circle.Height), Color.White, 0f, new Vector2(circle.Width / 2, circle.Height / 2), 1f, SpriteEffects.None, 1f);
            }           
            spriteBatch.Draw(texture, pos, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, new Vector2(texture.Width / 2, texture.Height /2), 1f, SpriteEffects.None, 1f );
        }

        internal Tower Copy()
        {
            return new Tower(texture, pos, range);
        }
    }
}
