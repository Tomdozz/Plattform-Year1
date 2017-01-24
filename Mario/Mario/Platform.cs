using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Platform : Gameobject
    {
     public Platform(Texture2D tex, Vector2 pos,  Rectangle hitbox)
            : base(tex, pos)
        {
            //srcrec = new Rectangle(0,0,0,0);
            this.hitBox = hitBox;
            // hitbox = new Rectangle(0, 0, 0, 0);
            // hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

     public override void HandleCollision(Gameobject g)
     {
         
     }
     public override void Update()
     {
         
     }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitBox, Color.White);
        }
    }
}
