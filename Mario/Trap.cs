using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Trap: Gameobject
    {
      public Trap(Texture2D tex, Vector2 pos)
            :base (tex, pos, new Rectangle(0,0, 50,50))
        {
            killHitBox = new Rectangle((int)pos.X, (int)pos.Y -11, 50, 20);
            
        }
        public override void Update(GameTime gameTime, int i)
        {
            throw new NotImplementedException();
        }
        public override void HandleCollision(Gameobject g)
        {
            throw new NotImplementedException();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitBox, srcRec, Color.Pink);
        }
    }
}
