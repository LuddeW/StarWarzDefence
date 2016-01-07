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
        
        
        bool isAactive = false;
        protected int range;
        protected float fireSpeed = 1f;
        Texture2D circleRed;
        Texture2D circleWhite;
        public bool canPlace = true;
        public Tower(Texture2D texture, Vector2 pos, int range) :base(texture, pos, new Vector2(texture.Width / 2, texture.Height / 2))
        {
            
            this.range = range;
            circleRed = CreateCircle(range, Color.White);
            circleWhite = CreateCircle(range, Color.Red);
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
                if (canPlace)
                {
                    spriteBatch.Draw(circleWhite, pos, new Rectangle(0, 0, circleWhite.Width, circleWhite.Height), Color.White, 0f, new Vector2(circleWhite.Width / 2, circleWhite.Height / 2), 1f, SpriteEffects.None, 1f);
                }
                else
                {
                    spriteBatch.Draw(circleRed, pos, new Rectangle(0, 0, circleRed.Width, circleRed.Height), Color.White, 0f, new Vector2(circleRed.Width / 2, circleRed.Height / 2), 1f, SpriteEffects.None, 1f);
                }
            }
            spriteBatch.Draw(texture, pos, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, Offset, 1f, SpriteEffects.None, 1f );
            //spriteBatch.Draw(texture, pos, Color.White);
        }

        internal Tower Copy()
        {
            return new Tower(texture, pos, range);
        }
    }
}
