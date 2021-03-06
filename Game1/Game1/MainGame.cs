﻿using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        protected internal SpriteBatch spriteBatch;
        
        private GameScene gameScene;
        private MenuScene menuScene;
        private GameOverScene gameOverScene;
        private Board _board;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();

            base.Initialize();
            _board = new Board();
            menuScene = new MenuScene(this);
            gameScene = new GameScene(this, _board);
            gameOverScene = new GameOverScene(this);
            IsMouseVisible = true;
            
            MenuState.IsShowMainMenuScene = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {  
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        ///
       
        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
                Exit();
            if (MenuState.IsShowMainMenuScene)
                menuScene.Update();
            if (MenuState.IsShowGameScene)
                gameScene.Update(gameTime);
            if (MenuState.IsShowGameOverScene)
                gameOverScene.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (MenuState.IsShowMainMenuScene)
                menuScene.Draw(spriteBatch, gameTime);
            if (MenuState.IsShowGameScene)
                gameScene.Draw(spriteBatch, gameTime);
            if (MenuState.IsShowGameOverScene)
                gameOverScene.Draw(spriteBatch, gameTime);
            base.Draw(gameTime);
        }

    }
}
