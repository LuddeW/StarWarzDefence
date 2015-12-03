using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace SuperStarWarzTowerDefence
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SimplePath path;
        Clock clock = new Clock();

        Texture2D spriteSheet;
        Vector2 pos;

        int spriteAnimation;
        int speed;
        int x;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>(@"stormtrop_spritesheet");
            pos = new Vector2();
            path = new SimplePath(GraphicsDevice);
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            clock.AddTime(0.003f);
            x++;
            pos = path.GetPos(path.beginT + x);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, new Rectangle((int)pos.X, (int)pos.Y, 100, 100), new Rectangle(185 * SpriteAnimation(), 0* 180, 195, 180), Color.White);
            path.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
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
