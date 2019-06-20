using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class MenuScene : DrawableGameComponent
    {
        Game game;

        Texture2D PlayButtonTexture;
        Texture2D ExitButtonTexture;
        Texture2D LogoTexture;
        Texture2D background;

        Rectangle recPlayButton;
        Rectangle recExitButton;
        Rectangle recLogo;

        Color PlayButtonColor = Color.White;
        Color ExitButtonColor = Color.White;

        MouseState mouseState;
        Rectangle Cursor;

        public MenuScene(Game game) : base(game)
        {
            this.game = game;
            LoadContent();
        }
       
        protected override void LoadContent()
        {
            background = game.Content.Load<Texture2D>("MenuBack");
            PlayButtonTexture = game.Content.Load<Texture2D>("ButtonGreen");
            ExitButtonTexture = game.Content.Load<Texture2D>("ButtonRed");
            LogoTexture = game.Content.Load<Texture2D>("blocks");
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);
            spriteBatch.Begin();
            spriteBatch.Draw(background, destinationRectangle: new Rectangle(0, 0, 600, 900), color: Color.Goldenrod);
            spriteBatch.Draw(LogoTexture, recLogo, Color.White);
            spriteBatch.Draw(PlayButtonTexture, recPlayButton, PlayButtonColor);
            spriteBatch.Draw(ExitButtonTexture, recExitButton, ExitButtonColor);
            spriteBatch.End();
        }
        public void Update()
        {
            CalculateItemsPositions();
            CalculateItemsSize();
            UpdateCursorPosition();
            ButtonsEvents();
        }
        /// <summary>
        /// Responsible for calculating optimal size of items
        /// </summary>
        private void CalculateItemsSize()
        {
            /*Calculate buttons size */
            int Height = GraphicsDevice.Viewport.Height / 12;
            int Width = GraphicsDevice.Viewport.Width / 2;
            recPlayButton.Height = Height;
            recPlayButton.Width = Width;
            //
            recExitButton.Height = Height;
            recExitButton.Width = Width;
            /* Calculate logo size */
            recLogo.Height = GraphicsDevice.Viewport.Height / 16;
            recLogo.Width = GraphicsDevice.Viewport.Width / 2;
            //
        }
        /// <summary>
        /// Responsible for calculating position of items depending on screen height and width
        /// </summary>
        private void CalculateItemsPositions()
        {
            int positionx = GraphicsDevice.Viewport.Width / 2 - recPlayButton.Width / 2;
            //
            recLogo.X = GraphicsDevice.Viewport.Width / 2 - recLogo.Width / 2;
            recLogo.Y = recLogo.Height + recPlayButton.Height / 2;
            //
            recPlayButton.X = positionx;
            recPlayButton.Y = recLogo.Height + 3 * recPlayButton.Height;
            //
            recExitButton.X = positionx;
            recExitButton.Y = recPlayButton.Y + 6 * recPlayButton.Height / 3;
        }
        /// <summary>
        /// Tracks cursor position
        /// </summary>
        private void UpdateCursorPosition()
        {
            /* Update Cursor position by Mouse */
            mouseState = Mouse.GetState();
            Cursor.X = mouseState.X; Cursor.Y = mouseState.Y;
        }
        /// <summary>
        /// Is responsible for catching interactions of buttons with cursor
        /// </summary>
        private void ButtonsEvents()
        {
            if ((recPlayButton.Intersects(Cursor)))
            {
                PlayButtonColor = Color.Yellow;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    PlayButtonColor = Color.Red;
                    MenuState.IsShowGameScene = true;
                }
            }
            else
                PlayButtonColor = Color.White;

            if ((recExitButton.Intersects(Cursor)))
            {
                ExitButtonColor = Color.Tomato;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    ExitButtonColor = Color.Red;
                    game.Exit();
                }
            }
            else
                ExitButtonColor = Color.White;
        }
    }
}
