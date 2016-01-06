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
        Clock clock = new Clock();

        GameHandler gameHandler;
        public enum GameState { StartMenu, GameScreen, EndScreen }
        GameState CurrentState = GameState.GameScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            
            base.Initialize();
            
        }

        
        protected override void LoadContent()
        {         
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameHandler = new GameHandler(this);
            gameHandler.LoadContent(spriteBatch);
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (CurrentState)
            {
                case GameState.StartMenu:
                    
                    break;
                case GameState.GameScreen:
                    gameHandler.Update(spriteBatch);
                    break;

                case GameState.EndScreen:

                    break;

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (CurrentState)
            {
                case GameState.StartMenu:
                    
                    break;
                case GameState.GameScreen:
                    gameHandler.Draw(spriteBatch);
                    break;
                case GameState.EndScreen:
     
                    break;
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
