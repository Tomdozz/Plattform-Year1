using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class Player: Animation
    {
        KeyboardState ks;
        bool IsOnGround = false;
        public Player(Texture2D tex, Vector2 pos, Rectangle srcrec, GameWindow window)
            : base(tex, pos, srcrec, window)
        {
            color = Color.Gainsboro;
            this.srcrec = new Rectangle(0, 0, 36, 50);
            //this.bX = window.ClientBounds.Width + 320;
            //this.bY = window.ClientBounds.Height;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 10, 15);
        }

        public void setIsonground(bool b)
        {
            IsOnGround = b;
        }
        public override void Update()
        {

            //hitBox.X = (int)pos.X;
            //hitBox.Y = (int)pos.Y;

            ks = Keyboard.GetState();

            if (!IsOnGround)
                speed.Y += 0.5f;
            speed.X = 0;

            if (ks.IsKeyDown(Keys.Right))
            {
                speed.X += 2;
            }
            if (ks.IsKeyDown(Keys.Left) && pos.X > 0)
            {
                speed.X -= 2;
            }
            
            if (ks.IsKeyDown(Keys.Space) && IsOnGround)
            {
                speed.Y = -10;
                IsOnGround = false;
            }

            pos += speed;

            //hitBox.X = (int)(pos.X >= 0 ? pos.X + 0.5f : pos.X - 0.5f);
            //hitBox.Y = (int)(pos.Y >= 0 ? pos.Y + 0.5f : pos.Y - 0.5f);

            //if (hitBox.Y + hitBox.Height > bY)
            //{
            //    pos.Y = bY - hitBox.Height;
            //    IsOnGround = true;
            //    speed.Y = 0;
            //}
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 30, 50);
            //hitBox = new Rectangle((int)pos.X, (int)pos.Y, 10, 15);
        }

        public override void HandleCollision(Gameobject other)
        {
            hitBox.Y = other.hitBox.Y - hitBox.Height;
            pos.Y = hitBox.Y;
            IsOnGround = true;
        }

        public virtual bool IsColliding(Gameobject p)
        {
            return hitBox.Intersects(p.hitBox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, srcrec, color, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            //spriteBatch.Draw(tex, srcrec, hitBox, Color.White);
        }

        public bool Dir()
        {
            return speed.Y > 0;
        }

        public Vector2 GetPos()
        {
            return pos;
        }

    }
}

