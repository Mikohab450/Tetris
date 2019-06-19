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
    class BlocksControl 
    {
        Game game;
        private DrawableGameComponent dG;
       
        public GraphicsDevice device;
        //public SpriteBatch spriteBatch;
        public Microsoft.Xna.Framework.Content.ContentManager ContentM;
        public Texture2D texture;
       // private MainGame game;

       // private Board board;

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
           // this.spriteBatch = spriteBatch;
           // this.Content = Content;

            // now you can load with content here.
          //  texture = Content.Load<Texture2D>("Art/Background/titleimg");
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, int shiftX, int shiftY)
        {
          //  device.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //spriteBatch.Draw(texture, new Rectangle(0, 0, 1024, 576), Color.White);
           
            spriteBatch.End();
        }
    }
}
