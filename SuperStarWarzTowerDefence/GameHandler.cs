using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spline;
using Microsoft.Xna.Framework;
using SuperStarWarzTowerDefence.GameObjects;
using SuperStarWarzTowerDefence.GameObjects.Tower;

namespace SuperStarWarzTowerDefence
{
    class GameHandler
    {
        Game1 game;

        SimplePath path;
        Clock clock = new Clock();

        List<Enemy> enemy;
        List<Tower> tower;

        Texture2D turtleSprite;
        Texture2D penguinKing;
        Texture2D penguinNormal;
        Texture2D penguinMad;
        Vector2 pos = new Vector2();
        int y = 0;

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
            
            path = new SimplePath(game.GraphicsDevice);
            enemy = new List<Enemy>();
            tower = new List<Tower>();
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
            ObjectFactory();
        }

        private void ObjectFactory()
        {
            if (y <1)
            {
                Enemy e = new Enemy(turtleSprite, pos, game);
                enemy.Add(e);
                Tower t = new Tower(penguinMad, new Vector2(100, 100));
                tower.Add(t);
                y++;
            }          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy e in enemy)
            {
                e.Draw(spriteBatch);
            }
            foreach (Tower t in tower)
            {
                t.Draw(spriteBatch);
            }
            spriteBatch.Draw(penguinKing, new Rectangle(0, 0, penguinKing.Width, penguinKing.Height), Color.White);
            path.Draw(spriteBatch);
            spriteBatch.Draw(penguinNormal, new Rectangle(300,300, penguinNormal.Width, penguinNormal.Height), Color.White);
        }
    }
}
