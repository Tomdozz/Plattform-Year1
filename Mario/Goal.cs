using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Goal: Animation
    {
        bool IsOnground = false;

        public Goal(Texture2D tex, Vector2 pos)
            : base(tex, pos, new Rectangle(0, 0, 52, 55))
        {
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }


        public override bool isColliding(Gameobject other)
        {
            return hitBox.Intersects(other.hitBox);
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitBox, Color.White);
          
        }
    }
}
