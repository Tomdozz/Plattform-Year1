using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Animation : Gameobject
    {
        protected SpriteEffects se;
        protected Vector2 speed;
        double frameTimer, frameInterval;
        int frame;

        public Animation(Texture2D tex, Vector2 pos, Rectangle srcRec)
            : base(tex, pos, srcRec)
        {
            frameTimer = 100;
            frameInterval = 100;
        }

        public override void Update(GameTime gameTime, int i)
        {
            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                frame++;
                srcRec.X = (frame % 4) * i;
            }
        }
        public override bool isColliding(Mario.Gameobject g)
        {
            return base.isColliding(g);
        }
        public override void HandleCollision(Gameobject g)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}


