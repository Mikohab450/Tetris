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
    class MenuScene : DrawableGameComponent
    {
        Game game;

        Texture2D PlayButtonTexture;
        Texture2D ExitButtonTexture;
        Texture2D LogoTexture;
       
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
            PlayButtonTexture = game.Content.Load<Texture2D>("ButtonRed");
            ExitButtonTexture = game.Content.Load<Texture2D>("ButtonGreen");
            LogoTexture = game.Content.Load<Texture2D>("blocks");
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
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
        private void CalculateItemsPositions()
        {

            /* Calculate button position */
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
                PlayButtonColor = Color.Green;
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
                ExitButtonColor = Color.Green;
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
