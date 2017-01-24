using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Animation : Gameobject
    {
        
        protected int bX;
        protected int bY;
        protected Vector2 speed;
        protected Color color;
        protected Rectangle srcrec;

        public Animation(Texture2D tex, Vector2 pos, Rectangle srcrec, GameWindow window)
            : base(tex, pos)
        {
            //this.bX = window.ClientBounds.Width;
            //this.bY = window.ClientBounds.Height;
            this.speed = new Vector2(1, 0);
            this.color = Color.Navy;
            //this.srcrec = new Rectangle (0,0,18,20);
        }

        public override void Update()
        {
            //pos += speed;

            //hitBox.X = (int)pos.X;
            //hitBox.Y = (int)pos.Y;

            //if (pos.X <= 0 && speed.X < 0 || pos.X + tex.Width >= bX && speed.X > 0)
            //    speed.X *= -1;
            //if (pos.Y <= 0 && speed.Y < 0 || pos.Y + tex.Height >= bY && speed.Y > 0)
            //    speed.Y *= -1;



        }
        public override void HandleCollision(Gameobject g)
        {
            //pos -= speed * 2;
            //speed *= -1;
            //hitBox.X = (int)pos.X;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(tex, pos, srcrec, color, 0, new Vector2(tex.Width / 4.0f, tex.Height / 4.0f), 1, SpriteEffects.None, 0);
           
        }
    }

}
    

