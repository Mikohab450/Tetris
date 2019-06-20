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
        static public bool IsRestart = true;
        Rectangle recPlayButton;
        Rectangle recExitButton;
        Rectangle recLogo;
        private static Texture2D rect;

        private float cols = 7;
        private float rows = 17;
        private int width = 400;
        private int height = 880;
        protected internal float gridSize = 40;
        private float centerX = 192;
        private float centerY = 488;
        public int shiftY = 9;
        public int shiftX = 32;
        private int scorePos = 515;
        private Board board;// = new Board();
        private GameLogic gameLogic = new GameLogic();
        private Score score = new Score();

    
        public GameScene(Game game, Board board) : base(game)
        {
            this.board = board;
            this.game = game;
            LoadContent();
        }

        protected override void LoadContent()
        {
            background = game.Content.Load<Texture2D>("Bck2");
            font = game.Content.Load<SpriteFont>("ScoreGame");
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(background, destinationRectangle: new Rectangle(0, 0, 600, 900), Color.Silver);
            for (float x = -cols; x < cols; x++)
            {
                Rectangle rectangle = new Rectangle((int) (centerX + x * gridSize), shiftY, 1, height);
                spriteBatch.Draw(texture1px, rectangle, Color.SteelBlue);
            }

            for (float y = -rows; y < rows; y++)
            {
                Rectangle rectangle = new Rectangle(shiftX, (int) (centerY + y * gridSize), width, 1);
                spriteBatch.Draw(texture1px, rectangle, Color.SteelBlue);
            }

            spriteBatch.DrawString(font, "SCORE", new Vector2(scorePos - font.MeasureString("SCORE").X / 2, 520),
                Color.White);
            spriteBatch.DrawString(font, Score.getScore().ToString(),
                new Vector2(scorePos - font.MeasureString(Score.getScore().ToString()).X / 2, 560), Color.White);

            for (int i = 0; i < 4; i++)
            {
                DrawRectangle(spriteBatch,
                    new Rectangle((board.GetFigure()[i].position.Y * 40 + shiftX + 1), (board.GetFigure()[i].position.X * 40 + shiftY),
                        39, 39), board.GetFigure()[i].Color);
            }

            for (int i = 0; i < board.GetWidth(); i++)
            {
                for (int j = 0; j < board.GetLenght(); j++)
                {
                    if (board[j, i] != null)
                        DrawRectangle(spriteBatch,
                          new Rectangle((i * 40 + shiftX + 1), (j * 40 + shiftY),
                              39, 39), board[j, i].Color);
                }
            }

            DrawNext(spriteBatch,board);

            spriteBatch.End();
          //  gameLogic.Draw(spriteBatch, gameTime);
        }

        public void Update(GameTime gameTime)
        {
            if (IsStart)
            {
                texture1px = new Texture2D(GraphicsDevice, 1, 1);
                texture1px.SetData(new Color[] {Color.White});
            }

            if (IsRestart)
            {
                board.GetScore().ClearScore();
                IsRestart = false;
            }

            gameLogic.Update(gameTime, board);
        }

        private void DrawRectangle(SpriteBatch spriteBatch, Rectangle coords, Color color)
        {
            if (rect == null)
            {
                rect = new Texture2D(GraphicsDevice, 1, 1);
                rect.SetData(new[] {Color.White});
            }

            spriteBatch.Draw(rect, coords, color);
        }

        private void DrawNext(SpriteBatch spriteBatch, Board board)
        {
            SingleBlock [,]tab = new SingleBlock[5,8];

            for (int i = 0; i < 4; i++)
            {
                tab[board.GetNext()[i].position.X, board.GetNext()[i].position.Y] = board.GetNext()[i];
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(tab[i,j] != null)
                    DrawRectangle(spriteBatch,
                        new Rectangle((i * 30 + 1 + scorePos - 55), (j * 30 + shiftY + 270),
                            28, 28), tab[i,j].Color);

                }
            }
        }
    }

}


