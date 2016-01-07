using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spline;
using Microsoft.Xna.Framework;
using SuperStarWarzTowerDefence.GameObjects;
using SuperStarWarzTowerDefence.GameObjects.Tower;
using Microsoft.Xna.Framework.Input;

namespace SuperStarWarzTowerDefence
{
    class GameHandler
    {
        public static Game1 game;

        SimplePath path;
        Clock clock = new Clock();
        MapHandler mh;
        List<Enemy> enemy;
        List<Tower> tower;
        List<Shot> shot;
        Emitter emitter;
        float floorpos = 0;
        int range = 150;
        RenderTarget2D renderTarget;
        Texture2D turtleSprite;
        Texture2D penguinKing;
        Texture2D penguinNormal;
        Texture2D penguinMad;
        Texture2D floor;
        public static Texture2D test;
        public Texture2D shotsprite;
        Tower selcetedTower;
        //Vector2 pos = new Vector2();
        KeyboardState prevKeyState = new KeyboardState();
        ButtonState prevLeftMouseButtonState = ButtonState.Released;

        public GameHandler(Game1 game)
        {
            GameHandler.game = game;
            renderTarget = new RenderTarget2D(game.GraphicsDevice, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            mh = new MapHandler(game.GraphicsDevice);
            floor = game.Content.Load<Texture2D>(@"floortd");
            turtleSprite = game.Content.Load<Texture2D>(@"Turtle");
            penguinKing = game.Content.Load<Texture2D>(@"Penguin_King");
            penguinMad = game.Content.Load<Texture2D>(@"Penguin_Mad");
            penguinNormal = game.Content.Load<Texture2D>(@"Penguin_Normal");
            shotsprite = game.Content.Load<Texture2D>(@"snowball");
            test = game.Content.Load<Texture2D>(@"snowball");
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(game.Content.Load<Texture2D>("circle"));
            emitter = new Emitter(textures, new Vector2(400, 240));
            
            enemy = new List<Enemy>();
            tower = new List<Tower>();
            shot = new List<Shot>();
            mh.LoadContent();
            path = mh.GetSimplePath();
            UpdateRenderTarget(spriteBatch);
        }

        private bool WasKeyPressed(Keys key, KeyboardState keyState)
        {
            return keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key);
        }

        private bool WasLeftMouseButtonPressed()
        {
            return Mouse.GetState().LeftButton == ButtonState.Pressed && prevLeftMouseButtonState == ButtonState.Released;
        }

        public void Update(SpriteBatch spriteBatch)
        {
            ObjectFactory();
            KeyboardState keyState = Keyboard.GetState();
            if (WasKeyPressed(Keys.D1, keyState))
            {
                Tower t = new NormalTower(penguinNormal, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y));
                selcetedTower = t;
            }
            if (WasKeyPressed(Keys.D2, keyState))
            {
                Tower t = new ExplosiveTower(penguinMad, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y));
                selcetedTower = t;
            }
            //if (WasKeyPressed(Keys.D3, keyState))
            //{
            //    Tower t = new Tower(penguinKing, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y));
            //    selcetedTower = t;
            //}
            if (selcetedTower != null)
            {
                selcetedTower.Pos = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            }
            prevKeyState = keyState;

            if (WasLeftMouseButtonPressed())
            {
                if (selcetedTower != null && canPlace(selcetedTower))
                {
                    Tower t = selcetedTower.Copy();
                    t.Activate();
                    tower.Add(t);
                    UpdateRenderTarget(spriteBatch);
                }
            }
            prevLeftMouseButtonState = Mouse.GetState().LeftButton;
            foreach (Enemy e in enemy)
            {
                e.Update();
            }
            if (selcetedTower != null)
            {
                canPlace(selcetedTower);
            }
            foreach (Tower t in tower)
            {
                foreach (Enemy e in enemy)
                {
                    Shoot(t, e);
                }
            }
            foreach (Shot s in shot)
            {
                s.Update();
            }
            emitter.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            emitter.Update();

            clock.AddTime(0.01f);
        }

        private void ObjectFactory()
        {
            
            
            if (clock.Timer() > 1)
            {
                Enemy e = new Enemy(turtleSprite, game, path);
                enemy.Add(e);
                clock.ResetTime();
            }
           
                
        }

        public void Shoot(Tower t, Enemy e)
        {
            if (Vector2.Distance(t.Pos, e.GetPos()) < range && clock.Timer() < 0.01f)
            {

                shot.Add(new Shot(shotsprite, t.Pos, e));
            }
        }

        public void KillEnemy()
        {
            foreach (Enemy e in enemy)
            {
                foreach (Shot s in shot)
                {
                    if (e.hitbox.Intersects(s.hitbox))
                    {
                        e.alive = false;
                        s.alive = false;
                    }
                }
            }
        }

        public void RemoveDeadObjects()
        {
            foreach (Enemy e in enemy)
            {
                for (int i = enemy.Count - 1; i >= 0; i--)
                {
                    if (!e.alive)
                    {
                        enemy.RemoveAt(i);
                    }
                }
            }
            foreach (Shot s in shot)
            {
                for (int e = shot.Count - 1; e >= 0; e--)
                {
                    if (!s.alive)
                    {
                        shot.RemoveAt(e);
                    }
                }
            }
        }

        public void DrawPath(SpriteBatch spriteBatch)
        {
            floorpos = path.beginT - 100;
            while (floorpos < path.endT)
            {
                floorpos += 15;
                spriteBatch.Draw(floor, path.GetPos(floorpos), new Rectangle(0, 0, floor.Width, floor.Height), Color.White, 0f, new Vector2(floor.Width / 2, floor.Height / 2), 1f, SpriteEffects.None, 1f);
            }
        }

        public bool canPlace(Tower t)
        {
            Color[] pixels = new Color[t.texture.Width * t.texture.Height];
            renderTarget.GetData(0, new Rectangle((int)(t.Pos.X - t.Offset.X), (int)(t.Pos.Y - t.Offset.Y), t.texture.Width, t.texture.Height), pixels, 0, pixels.Length);
            //renderTarget.GetData(0, new Rectangle((int)(t.Pos.X), (int)(t.Pos.Y), t.texture.Width, t.texture.Height), pixels, 0, pixels.Length);
            bool isColliding = t.PixelCollition(pixels, new Rectangle(0, 0, t.texture.Width, t.texture.Height));
            t.canPlace = isColliding;
            return !isColliding;
        }

        public void UpdateRenderTarget(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.SetRenderTarget(renderTarget);
            game.GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();
            DrawPath(spriteBatch);
            foreach (Tower t in tower)
            {
                t.Draw(spriteBatch);
            }
           spriteBatch.End();
            game.GraphicsDevice.SetRenderTarget(null);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
            emitter.Draw(spriteBatch);
            foreach (Enemy e in enemy)
            {
                e.Draw(spriteBatch);
            }

            if (selcetedTower != null)
            {
                selcetedTower.Draw(spriteBatch);
            }
            foreach (Shot s in shot)
            {
                s.Draw(spriteBatch);
            }

            //mh.Draw(spriteBatch);
            //spriteBatch.Draw(penguinKing, new Rectangle(0, 0, penguinKing.Width, penguinKing.Height), Color.White);
            //path.Draw(spriteBatch);
            //spriteBatch.Draw(penguinNormal, new Rectangle(300,300, penguinNormal.Width, penguinNormal.Height), Color.White);
        }
    }
}
