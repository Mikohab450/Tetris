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

        private bool IsStart = true;

        KeyboardState previousState;

        private TimeSpan timer = new TimeSpan(0, 0, 1);
        private TimeSpan timer2 = new TimeSpan(0, 0, 1);
        private TimeSpan timer3 = new TimeSpan(0, 0, 10);

        private GameScene gameScene;
        

     

        public void Update(GameTime gameTime, Board board)
        {
            KeyboardState state = Keyboard.GetState();
            if (IsStart)
            {
                //currentBlock.addToList(new SingleBlock((int)(2 * gameScene.gridSize) + gameScene.shiftX + 1, (int)(2 * gameScene.gridSize) + gameScene.shiftY,
                //    Color.Fuchsia));
                //currentBlock.addToList(new SingleBlock((int)(3 * gameScene.gridSize) + gameScene.shiftX + 1, (int)(2 * gameScene.gridSize) + gameScene.shiftY,
                //    Color.Fuchsia));
                //currentBlock.addToList(new SingleBlock((int)(4 * gameScene.gridSize) + gameScene.shiftX + 1, (int)(2 * gameScene.gridSize) + gameScene.shiftY,
                //    Color.Fuchsia));
               // currentBlock = new BlocksControl();
               
                
            }

            timers(gameTime,board);
            if (state.IsKeyUp(Keys.Left) & !previousState.IsKeyUp(Keys.Left))
                MenuState.IsShowGameOverScene = true;
               // board.current_figure.MoveLeft();
            if (state.IsKeyUp(Keys.Right) & !previousState.IsKeyUp(Keys.Right))
                board.current_figure.MoveRight();
            if (state.IsKeyUp(Keys.Space) & !previousState.IsKeyUp(Keys.Space))
                board.current_figure.Drop();
            if (state.IsKeyUp(Keys.Z) & !previousState.IsKeyUp(Keys.Z))
                board.current_figure.LeftRotation();
            if (state.IsKeyUp(Keys.X) & !previousState.IsKeyUp(Keys.X))
               board.current_figure.RightRotation();
            if (state.IsKeyUp(Keys.Down) & !previousState.IsKeyUp(Keys.Down))
                board.current_figure.MoveDown();
            previousState = state;
        }

        private void timers(GameTime gameTime, Board board)
        {
            if (timer > TimeSpan.Zero)
            {
                timer -= gameTime.ElapsedGameTime;
                if (timer <= TimeSpan.Zero)
                {
                   // currentBlock.updateList();
                    board.current_figure.MoveDown();
                    timer = timer2;
                }

            }
         
            // TODO: Add your update logic here
   
        }
    }
}
