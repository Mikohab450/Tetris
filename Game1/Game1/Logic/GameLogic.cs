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
    class GameLogic 
    {
        Game game;
        private Board board;
        KeyboardState previousState;
        private int lvl = 1;
        private TimeSpan timer = new TimeSpan(0, 0, 0, 0,1000);
        private TimeSpan timer2 = new TimeSpan(0, 0, 0, 0,1000);
        private TimeSpan timer3 = new TimeSpan(0, 0, 0, 0,100);

        private GameScene gameScene;

        public void Update(GameTime gameTime, Board board)
        {
            KeyboardState state = Keyboard.GetState();
            Timers(gameTime,board);
            MakeHarder(timer2,timer3,lvl);
            if (state.IsKeyUp(Keys.Left) & !previousState.IsKeyUp(Keys.Left))
                board.MoveFigureLeft();
            if (state.IsKeyUp(Keys.Right) & !previousState.IsKeyUp(Keys.Right))
                board.MoveFigureRight();
            if (state.IsKeyUp(Keys.Space) & !previousState.IsKeyUp(Keys.Space))
                board.DropFigure();
            if (state.IsKeyUp(Keys.Z) & !previousState.IsKeyUp(Keys.Z))
                board.FigureLeftRotation();
            if (state.IsKeyUp(Keys.X) & !previousState.IsKeyUp(Keys.X))
                board.FigureRightRotation();
            if (state.IsKeyUp(Keys.Down) & !previousState.IsKeyUp(Keys.Down))
                board.MoveFigureDown();
            previousState = state;
        }
        /// <summary>
        /// Calculates the game difficulty (block falling speed)
        /// </summary>
        private void Timers(GameTime gameTime, Board board)
        {
            if (timer > TimeSpan.Zero)
            {
                timer -= gameTime.ElapsedGameTime;
                if (timer <= TimeSpan.Zero)
                {
                    board.MoveFigureDown();
                    timer = timer2;
                }

            }
        }
        /// <summary>
        /// Increases the game difficulty depending on current score
        /// </summary>
        private void MakeHarder(TimeSpan timer2, TimeSpan timer3, int lvl)
        {
            if (Score.getScore() >= lvl * 3000)
            {
                lvl++;
            }
            TimeSpan milis = new TimeSpan(0,0,0,0,1000);
            for(int i = 0; i < lvl; i++) {
                timer2 = milis.Subtract(timer3);
            }
        }
    }
}
