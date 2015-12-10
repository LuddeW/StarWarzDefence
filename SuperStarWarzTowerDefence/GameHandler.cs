using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spline;
using Microsoft.Xna.Framework;
using SuperStarWarzTowerDefence.GameObjects;

namespace SuperStarWarzTowerDefence
{
    class GameHandler
    {
        Game1 game;

        SimplePath path;
        Clock clock = new Clock();

        List<Enemy> enemy;

        Texture2D turtleSprite;
        Texture2D penguinKing;
        Texture2D penguinNormal;
        Texture2D penguinMad;
        Vector2 pos;
        int x;


        public GameHandler(Game1 game)
        {
            this.game = game;
            
        }

        public void LoadContent()
        {
            turtleSprite = game.Content.Load<Texture2D>(@"Turtle");
            penguinKing = game.Content.Load<Texture2D>(@"Penguin_King");
            penguinMad = game.Content.Load<Texture2D>(@"Penguin_Mad");
            penguinNormal = game.Content.Load<Texture2D>(@"Penguin_Normal");
            pos = new Vector2();
            path = new SimplePath(game.GraphicsDevice);
            enemy = new List<Enemy>();
            TrutleFactory();
        }


        public void Update()
        {
            
            clock.AddTime(0.003f);
            foreach (Enemy e in enemy)
            {
                e.Update();
            }
            //x++;
            //pos = path.GetPos(path.beginT + x);
        }

        private void TrutleFactory()
        {
                Enemy e = new Enemy(turtleSprite, pos, game);
                enemy.Add(e);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(turtleSprite, new Rectangle((int)pos.X, (int)pos.Y, 50, 25), Color.White);
            foreach (Enemy e in enemy)
            {
                e.Draw(spriteBatch);
            }
            spriteBatch.Draw(penguinKing, new Rectangle(0, 0, penguinKing.Width, penguinKing.Height), Color.White);
            spriteBatch.Draw(penguinMad, new Rectangle(250, 250, penguinMad.Width, penguinMad.Height), Color.White);
            spriteBatch.Draw(penguinNormal, new Rectangle(300,300, penguinNormal.Width, penguinNormal.Height), Color.White);
        }
    }
}
