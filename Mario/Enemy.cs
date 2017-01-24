using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    class Enemy : Animation
    {
       public Enemy(Texture2D tex, Vector2 pos)
            : base(tex, pos, new Rectangle(0, 144, 45, 50))
        {
            speed.X = -2f;
            speed.Y = 5f;
            this.tex = tex;
            this.pos = pos;
        }
        
        public override void Update(GameTime gameTime, int i)
        {
            pos += speed;

            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 38, 50);

            base.Update(gameTime, 49);

            killHitBox.X = (int)(pos.X);
            killHitBox.Y = (int)(pos.Y);
        }

        public override void HandleCollision(Gameobject other)
        {
            if (hitBox.Center.X < other.hitBox.Left)
            {
                speed.X *= -1;
                se = SpriteEffects.None;
            }
            else if (hitBox.Center.X > other.hitBox.Right && other.hitBox.Center.Y < hitBox.Center.Y)
            {
                speed.X *= -1;
                se = SpriteEffects.FlipHorizontally;
            }
            else
            {
                hitBox.Y = other.hitBox.Y - hitBox.Height;
                pos.Y = hitBox.Y;             
            }
        }
        public override bool isColliding(Gameobject other)
        {
            return hitBox.Intersects(other.hitBox);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitBox, srcRec, Color.White, 0,  new Vector2(0,0), se, 0);
        }
    }
}

