using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    abstract class Gameobject
    {
        protected Vector2 pos;
        protected Texture2D tex;
        protected Rectangle srcRec;
        public Rectangle hitBox;
        public Rectangle killHitBox;
        

        public Gameobject(Texture2D tex, Vector2 pos, Rectangle srcRec)
        {
            this.tex = tex;
            this.pos = pos;
            this.srcRec = srcRec;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
            killHitBox = new Rectangle((int)pos.X, (int)pos.Y, 38, 2);
 
        }
        public abstract void Update(GameTime gameTime, int i);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleCollision(Gameobject g);
        
        public virtual bool isColliding(Gameobject g)
        {
            if (hitBox.Intersects(g.hitBox))
            {
                if (((hitBox.Y + hitBox.Height) - 100) <= g.hitBox.Y)
                    return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        public bool PixelCollision(Gameobject other)
        {
            Color[] dataA = new Color[srcRec.Width * srcRec.Height];
            tex.GetData(0, srcRec, dataA, 0, srcRec.Width * srcRec.Height);
            Color[] dataB = new Color[other.srcRec.Width * other.srcRec.Height];
            other.tex.GetData(0, srcRec, dataB, 0, other.srcRec.Width * other.srcRec.Height);

            int top = Math.Max(hitBox.Top, other.hitBox.Top);
            int bottom = Math.Min(hitBox.Bottom, other.hitBox.Bottom);
            int left = Math.Max(hitBox.Left, other.hitBox.Left);
            int right = Math.Min(hitBox.Right, other.hitBox.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color colorA = dataA[(x - hitBox.Left) +
                    (y - hitBox.Top) * hitBox.Width];
                    Color colorB = dataB[(x - other.hitBox.Left) +
                    (y - other.hitBox.Top) * other.hitBox.Width];
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }     
    }
}

