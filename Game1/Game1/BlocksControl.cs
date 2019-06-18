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
    class BlocksControl : Game
    {
        private static Texture2D rect;
        public GraphicsDevice device;
        public SpriteBatch spriteBatch;
        public Microsoft.Xna.Framework.Content.ContentManager ContentM;
        public Texture2D texture;
        private MainGame game;
        public SingleBlock singleBlock;

        private List<SingleBlock> Bloki = new List<SingleBlock>();

        protected internal void AddToList(SingleBlock newBlock)
        {
            Bloki.Add(newBlock);
        }

        protected internal void goLeft()
        {
            foreach (SingleBlock bloczek in this.Bloki)
            {
                bloczek.position.X--;
                //Posx -= (int)(40);
            }
        }
        protected internal void goRight()
        {
            foreach (SingleBlock bloczek in this.Bloki)
            {
               // bloczek.position.X++;
              //;= (int)(40);
            }
        }

        protected internal void updateList()
        {
            foreach (SingleBlock bloczek in this.Bloki)
            {
               // bloczek.AddTo_X_Posistion((int)(40));
            }
        }
        protected internal void LoadContent(GraphicsDevice device, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            this.device = device;
            this.spriteBatch = spriteBatch;
            this.Content = Content;

            // now you can load with content here.
          //  texture = Content.Load<Texture2D>("Art/Background/titleimg");
        }
        private void DrawRectangle(Rectangle coords, Color color)
        {
            if (rect == null)
            {
                rect = new Texture2D(device, 1, 1);
                rect.SetData(new[] { Color.White });
            }
            spriteBatch.Draw(rect, coords, color);
        }

        public void Draw(GameTime gameTime, int shiftX, int shiftY)
        {
          //  device.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //spriteBatch.Draw(texture, new Rectangle(0, 0, 1024, 576), Color.White);
            DrawRectangle(new Rectangle((int)shiftX, (int)shiftY, 39, 39), Color.IndianRed);
            foreach (SingleBlock block in Bloki)
            {
                DrawRectangle(new Rectangle((block.position.X*40), (block.position.Y*40), 39, 39), block.Color);
            }
            spriteBatch.End();
        }
    }
}
