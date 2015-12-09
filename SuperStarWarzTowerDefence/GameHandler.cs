using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spline;
using Microsoft.Xna.Framework;

namespace SuperStarWarzTowerDefence
{
    class GameHandler
    {
        Game1 game;

        SimplePath path;
        Clock clock = new Clock();

        Texture2D spriteSheet;
        Texture2D background;
        Vector2 pos;

        int spriteAnimation;
        int x;


        public GameHandler(Game1 game)
        {
            this.game = game;
        }

        public void LoadContent()
        {
            spriteSheet = game.Content.Load<Texture2D>(@"stormtrop_spritesheet");
            background = game.Content.Load<Texture2D>(@"background");
            pos = new Vector2();
            path = new SimplePath(game.GraphicsDevice);
        }

        public void Update()
        {
            clock.AddTime(0.003f);
            x++;
            pos = path.GetPos(path.beginT + x);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(-50, -50, 900, 600), Color.White);
            spriteBatch.Draw(spriteSheet, new Rectangle((int)pos.X, (int)pos.Y, 100, 100), new Rectangle(186 * SpriteAnimation(), 0 * 180, 190, 180), Color.White, 0f, new Vector2(90, 90), SpriteEffects.None, 1f);
            spriteBatch.Draw(spriteSheet, new Rectangle(0, 0, 100, 100), new Rectangle(186 * 8, 0, 195, 160), Color.White);
        }

        private int SpriteAnimation()
        {
            if (clock.Timer() > 0.1f)
            {
                spriteAnimation++;
                clock.ResetTime();
                if (spriteAnimation > 3)
                {
                    spriteAnimation = 0;
                }
            }
            return spriteAnimation;
        }
    }
}
