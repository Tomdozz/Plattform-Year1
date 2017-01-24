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
        public Platform(Texture2D tex, Vector2 pos, Rectangle hitbox)
            : base(tex, pos, new Rectangle(0,0,50,50))
        {
            this.hitBox = hitBox;
        }

        public override void HandleCollision(Gameobject g)
        {

        }
        public override void Update(GameTime gameTime, int i)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, hitBox, Color.White);
        }
    }
}
