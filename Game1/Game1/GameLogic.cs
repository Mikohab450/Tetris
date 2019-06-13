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

        private bool IsStart = true;

        KeyboardState previousState;

        private TimeSpan timer = new TimeSpan(0, 0, 1);
        private TimeSpan timer2 = new TimeSpan(0, 0, 1);
        private TimeSpan timer3 = new TimeSpan(0, 0, 10);

        private GameScene gameScene;

        private BlocksControl currentBlock;


        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            currentBlock.Draw(gameTime, gameScene.shiftX + 1, gameScene.shiftY);
        }

        public void Update(GameTime gameTime)
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
            }

            timers(gameTime);
            if (state.IsKeyUp(Keys.Left) & !previousState.IsKeyUp(Keys.Left))
                currentBlock.goLeft();
            if (state.IsKeyUp(Keys.Right) & !previousState.IsKeyUp(Keys.Right))
                currentBlock.goRight();
            previousState = state;
        }

        private void timers(GameTime gameTime)
        {
            if (timer > TimeSpan.Zero)
            {
                timer -= gameTime.ElapsedGameTime;
                if (timer <= TimeSpan.Zero)
                {
                   // currentBlock.updateList();

                    timer = timer2;
                }

            }
         
            // TODO: Add your update logic here
   
        }
    }
}
