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
        Texture2D background;
        Vector2 pos;

        int spriteAnimation;
        int x;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
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
            background = Content.Load<Texture2D>(@"background");
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
            spriteBatch.Draw(background, new Rectangle(-50, -50, 900, 600), Color.White);
            spriteBatch.Draw(spriteSheet, new Rectangle((int)pos.X, (int)pos.Y, 100, 100), new Rectangle(186 * SpriteAnimation(), 0* 180, 190, 180), Color.White, 0f, new Vector2(90, 90), SpriteEffects.None, 1f);
            spriteBatch.Draw(spriteSheet, new Rectangle(0, 0, 100, 100), new Rectangle(186 * 8, 0, 195, 160), Color.White);
            //path.Draw(spriteBatch);
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
