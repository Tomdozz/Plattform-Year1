using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Enemy : Animation
    {
        protected int bX, bY;
        protected Vector2 speed;
        public Enemy(Texture2D tex, Vector2 pos, Rectangle srcrec, GameWindow window)
            : base(tex, pos, srcrec, window)
        {
            this.speed = new Vector2(Game1.rand.Next(-2, 3), Game1.rand.Next(-2, 3));

        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.Red);
        }
    }
}

