using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class GameScene : DrawableGameComponent
    {
        Game game;

        Texture2D background;
        SpriteFont font;
        private Texture2D texture1px;
        private bool IsStart = true;

        Rectangle recPlayButton;
        Rectangle recExitButton;
        Rectangle recLogo;

        private float cols = 7;
        private float rows = 17;
        private int width = 400;
        private int height = 880;
        protected internal float gridSize = 40;
        private float centerX = 192;
        private float centerY = 488;
        protected internal int shiftY = 9;
        protected internal int shiftX = 32;

        private GameLogic gameLogic = new GameLogic();
        public GameScene(Game game) : base(game)
        {
            this.game = game;
            LoadContent();
        }

        protected override void LoadContent()
        {
            background = game.Content.Load<Texture2D>("Bck");
            font = game.Content.Load<SpriteFont>("Score");
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(background, destinationRectangle: new Rectangle(0, 0, 600, 900));
            for (float x = -cols; x < cols; x++)
            {
                Rectangle rectangle = new Rectangle((int)(centerX + x * gridSize), shiftY, 1, height);
                spriteBatch.Draw(texture1px, rectangle, Color.SteelBlue);
            }

            for (float y = -rows; y < rows; y++)
            {
                Rectangle rectangle = new Rectangle(shiftX, (int)(centerY + y * gridSize), width, 1);
                spriteBatch.Draw(texture1px, rectangle, Color.SteelBlue);
            }

            spriteBatch.DrawString(font, "SCORE", new Vector2(480, 520), Color.White);
            //spriteBatch.DrawString(font, score.ToString(), new Vector2(485, 550), Color.White);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            if (IsStart)
            {
                texture1px = new Texture2D(GraphicsDevice, 1, 1);
                texture1px.SetData(new Color[] { Color.White });
            }

            gameLogic.Update(gameTime);
        }
    }
}
