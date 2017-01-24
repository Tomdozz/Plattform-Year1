using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class Coin: Animation
    {
        public Coin(Texture2D tex, Vector2 pos)
            :base (tex, pos, new Rectangle(0,0,50,50))
        {
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
        }

        public override bool isColliding(Gameobject other)
        {
            return hitBox.Intersects(other.hitBox);
        }

        public override void Update(GameTime gameTime, int i)
        {
            base.Update(gameTime, 50);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitBox, srcRec, Color.White);
        }
    }
}
