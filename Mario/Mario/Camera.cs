using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Camera
    {
        Player target;
        Rectangle ScreenBounds, LevelBounds;

        Matrix translationMatrix;

        public Matrix TranslationMatrix
        {
            get { return translationMatrix; }
        }

        public Camera(Player target, Rectangle ScreenBounds, Rectangle LevelBounds)
        {
            this.target = target;
            this.ScreenBounds = ScreenBounds;
            this.LevelBounds = LevelBounds;
        }

        public void Update()
        {
            //float translationX = MathHelper.Clamp(0, -(target.GetPos().X - ScreenBounds.Width / 2), LevelBounds.Width - ScreenBounds.Width / 2);
            float translationX = translationX = MathHelper.Clamp(-target.GetPos().X + 200, -1000000, 100000); ;

            if(target.GetPos().X < 200)
            {
                translationX = 0;
            }
            if(target.GetPos().X > 1100)
            {
                translationX = -900;
            }
    
            float translationY = MathHelper.Clamp(0, -(target.GetPos().Y - ScreenBounds.Height / 2), LevelBounds.Height - ScreenBounds.Height / 2);


            translationMatrix = Matrix.CreateTranslation(translationX, translationY, 0);
            //translationMatrix = Matrix.CreateTranslation(translationX, 0, 0);
        }




        //Player target;
        //Rectangle ScreenBounds, LevelBounds;
        //Viewport view;
        //Vector2 centre;

        //public Matrix matrix;

        //public Camera(Viewport newView)
        //{
        //    view = newView;
        //}

        //public void Update(GameTime gametime, Player player)
        //{
        //    centre = new Vector2((player.pos.X + player.hitBox.Width / 2) - 400, (player.pos.Y + player.hitBox.Height / 2) - 375);
        //    matrix = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        //}
    }
}

