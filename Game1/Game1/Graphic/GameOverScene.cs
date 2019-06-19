﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class GameOverScene : DrawableGameComponent
    {
        Game game;

        Texture2D background;
        SpriteFont font;

        Rectangle recPlayButton;
        Rectangle recExitButton;
        Texture2D PlayButtonTexture;
        Texture2D ExitButtonTexture;

        Color PlayButtonColor = Color.White;
        Color ExitButtonColor = Color.White;

        MouseState mouseState;
        Rectangle Cursor;

        private Score score = new Score();
        public GameOverScene(Game game) : base(game)
        {
            this.game = game;
            LoadContent();
        }

        protected override void LoadContent()
        {
            background = game.Content.Load<Texture2D>("GameOver");
            font = game.Content.Load<SpriteFont>("Score");
            PlayButtonTexture = game.Content.Load<Texture2D>("GameOverAgain");
            ExitButtonTexture = game.Content.Load<Texture2D>("GameOverExit");
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(background, destinationRectangle: new Rectangle(0, 0, 600, 900), Color.White*0.05f);
            spriteBatch.Draw(PlayButtonTexture, destinationRectangle: new Rectangle(0, 0, 600, 900), PlayButtonColor);
            spriteBatch.Draw(ExitButtonTexture, destinationRectangle: new Rectangle(0, 0, 600, 900), ExitButtonColor);
            spriteBatch.DrawString(font, score.getScore().ToString(), new Vector2(GraphicsDevice.Viewport.Width / 2 - font.MeasureString(score.getScore().ToString()).X /2, 360), new Color(176, 47, 31));
            

            spriteBatch.End();
        }

        public void Update()
        {
            CalculateItemsPositions();
            CalculateItemsSize();
            UpdateCursorPosition();
            ButtonsEvents();
        }

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
           
        }
        private void CalculateItemsPositions()
        {

            /* Calculate button position */
            int positionx = GraphicsDevice.Viewport.Width / 2 - recPlayButton.Width / 2;
            //
          
            //
            recPlayButton.X = positionx;
            recPlayButton.Y = 6 * recPlayButton.Height;
            //
            recExitButton.X = positionx;
            recExitButton.Y = recPlayButton.Y + 8 * recPlayButton.Height / 3;
        }

        private void UpdateCursorPosition()
        {
            /* Update Cursor position by Mouse */
            mouseState = Mouse.GetState();
            Cursor.X = mouseState.X; Cursor.Y = mouseState.Y;
        }
        private void ButtonsEvents()
        {
            if ((recPlayButton.Intersects(Cursor)))
            {
                PlayButtonColor = Color.Pink;
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