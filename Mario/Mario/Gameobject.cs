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
        public Vector2 pos;
        protected Texture2D tex;
        public Rectangle hitBox;
        float radius;
        public Gameobject(Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
            radius = (tex.Width / 2);
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual bool CircleCollision(Gameobject other)
        {
            return Vector2.Distance(pos, other.pos) < (radius + other.radius);
        }

        public abstract void HandleCollision(Gameobject g);

        public virtual bool isColliding(Platform g)
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
            Color[] dataA = new Color[tex.Width * tex.Height];
            tex.GetData(dataA);
            Color[] dataB = new Color[other.tex.Width * other.tex.Height];
            other.tex.GetData(dataB);

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

