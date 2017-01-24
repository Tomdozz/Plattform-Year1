using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class Player : Animation
    {
        KeyboardState ks;
        bool IsOnGround = false;
        bool Moving = false;

        public Player(Texture2D tex, Vector2 pos)
            : base(tex, pos, new Rectangle(0, 0, 36, 50))
        {
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 10, 15);   
        }


        public override void Update(GameTime gameTime, int i)
        {
            PlayerAnimation(gameTime);
            PlayerMovement();
  
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 30, 46);
        }

        void PlayerAnimation(GameTime gameTime)
        {
            if (speed.X != 0)
            {
                Moving = true;
            }
            else
            {
                Moving = false;
                srcRec = new Rectangle(0, 0, 36, 50);
            }


            if (Moving && IsOnGround)
            {
                base.Update(gameTime, 36);
            }
        }

        void PlayerMovement()
        {
            pos += speed;
            ks = Keyboard.GetState();
            if (!IsOnGround)
            {
                speed.Y += 0.5f;
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                speed.X = 5;
                se = SpriteEffects.None;
            }

            else if (ks.IsKeyDown(Keys.Left) && pos.X > 0)
            {
                speed.X = -5;
                se = SpriteEffects.FlipHorizontally;
            }

            else
            {
                speed.X = 0;
            }

            if (ks.IsKeyDown(Keys.Space) && IsOnGround)
            {
                speed.Y = -10;
                IsOnGround = false;
                srcRec = new Rectangle(210, 0, 36, 50);
            }
            if (pos.Y > 700)
            {
                Game1.Lives--;
                resetPosition();
            }

        }

        public override void HandleCollision(Gameobject other)
        {
            if(hitBox.Center.X < other.hitBox.Left)
            {
                pos.X = other.hitBox.Left - srcRec.Width + speed.X;

            }
            else if(hitBox.Center.X > other.hitBox.Right && other.hitBox.Center.Y < hitBox.Center.Y + 30)
            {
                pos.X = other.hitBox.Right + speed.X;
            }
            else if (pos.Y > (other.hitBox.Y + (other.hitBox.Height / 2)))
            {
                pos.Y = other.hitBox.Y + other.hitBox.Height;
                speed.Y = 1;
                IsOnGround = false;
            }
            else
            {
                hitBox.Y = other.hitBox.Y - hitBox.Height;
                pos.Y = hitBox.Y;
                IsOnGround = true;
            }
        }

        public override bool isColliding(Gameobject p)
        {
            return hitBox.Intersects(p.hitBox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, srcRec, Color.White, 0, Vector2.Zero, 1, se, 0);
        }

        public Vector2 GetPos()
        {
            return pos;
        }        
        public Vector2 GetSpeed()
        { 
            return speed;
        }
        public void SetSpeed(int newSpeed)
        { 
            speed.Y = newSpeed; 
        }
        public void setIsonground(bool b)
        {
            IsOnGround = b;
        }
        public void resetPosition()
        {
            this.pos = new Vector2(0, 250);
        }
    }
}

