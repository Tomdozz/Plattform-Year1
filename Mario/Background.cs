using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class Background
    {      
        List<Vector2> foreground, middleground, background;
        int fgSpacing, mgSpacing, bgSpacing =0;
        float fgSpeed, mgSpeed, bgSpeed;
        Texture2D[] tex = new Texture2D[3];
        GameWindow window;  
        
        public Background(ContentManager Content, GameWindow window) 
        {                     
            this.window = window;  
           
            tex[0] = Content.Load<Texture2D>("background");  
            tex[1] = Content.Load<Texture2D>("Cloud");       
            tex[2] = Content.Load<Texture2D>("Cloud");


            MiddlegroundInfo(window);
            ForegroundInfo(window);
            BackgroundInfo(window); 
        }

        public void Update() 
        {
            ForegroundUpdate();
            MiddlegroundUpdate();
            BackgroundUpdate();
        }

        void BackgroundInfo(GameWindow window)
        {
            background = new List<Vector2>();
            bgSpacing = window.ClientBounds.Width;
            bgSpeed = -0.90f;
            for (int i = 0; i < (window.ClientBounds.Width / bgSpacing) + 15; i++)
            {
                background.Add(new Vector2(i * bgSpacing, window.ClientBounds.Height - tex[0].Height));

            }
        }
        void ForegroundInfo(GameWindow window)
        {
            foreground = new List<Vector2>();
            fgSpacing = window.ClientBounds.Width;
            fgSpeed = -0.80f;
            for (int i = 0; i < (window.ClientBounds.Width / fgSpacing) + 15; i++)
            {
                foreground.Add(new Vector2(i * fgSpacing, window.ClientBounds.Height - tex[1].Height - (int)(tex[1].Height * 1.0)));

            }
        }
        void MiddlegroundInfo(GameWindow window)
        {
            middleground = new List<Vector2>();
            mgSpacing = window.ClientBounds.Width / 2;
            mgSpeed = -1.0f;
            for (int i = 0; i < (window.ClientBounds.Width / mgSpacing) + 15; i++)
            {
                middleground.Add(new Vector2(i * mgSpacing, window.ClientBounds.Height - tex[2].Height - (int)(tex[2].Height * 2)));

            }
        }  
        void ForegroundUpdate()
        {
            for (int i = 0; i < foreground.Count; i++)
            {
                foreground[i] = new Vector2(foreground[i].X + fgSpeed, foreground[i].Y);

                if (foreground[i].X <= -fgSpacing)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = foreground.Count - 1;
                    }

                    foreground[i] = new Vector2(foreground[j].X + fgSpacing - 1, foreground[i].Y);

                }
            }
        }
        void MiddlegroundUpdate()
        {
            for (int i = 0; i < middleground.Count; i++)
            {
                middleground[i] = new Vector2(middleground[i].X + mgSpeed, middleground[i].Y);

                if (middleground[i].X <= -mgSpacing)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = middleground.Count - 1;
                    }

                    middleground[i] = new Vector2(middleground[j].X + mgSpacing - 1, middleground[i].Y);

                }
            }
        }
        void BackgroundUpdate()
        {
            for (int i = 0; i < background.Count; i++)
            {
                background[i] = new Vector2(background[i].X + bgSpeed, background[i].Y);
                if (background[i].X <= -bgSpacing)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = background.Count - 1;
                    }
                    background[i] = new Vector2(background[j].X + bgSpacing - 1, background[i].Y);
                }
            }
        }        
        public void Draw(SpriteBatch sb)
        {
            foreach (Vector2 v in background)            
            {    
               sb.Draw(tex[0], v, Color.White);              
            }

            foreach (Vector2 v in foreground)
            {
                sb.Draw(tex[1], v, Color.White);
            }

            foreach (Vector2 v in middleground)
            {
                sb.Draw(tex[2], v, Color.White);
            }      
        }  
    }   
}


