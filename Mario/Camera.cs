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
        Player player;
        Matrix translationMatrix;

        public Matrix TranslationMatrix
        {
            get { return translationMatrix; }
        }

        public Camera(Player player)
        {
            this.player = player;
        }

        public void Update()
        {
            float translationX = translationX = MathHelper.Clamp(-player.GetPos().X + 400, -1000000, 100000);     
            if(player.GetPos().X < 400)
            {
                translationX = 0;
            }
            if(player.GetPos().X > 5400)
            {
                translationX = -5000;
            }    
            translationMatrix = Matrix.CreateTranslation(translationX, 0 , 0);
        }
    }
}

