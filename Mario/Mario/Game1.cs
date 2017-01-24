using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        bool collision;
        List<Background> backgorund = new List<Background>();
        List<Platform> gameObjects = new List<Platform>();
        Player player;
        
        Texture2D tex, maptex;

        Map map;

        Camera camera;
       
        public static Random rand = new Random();

        string text;

        bool start = false;

        SpriteFont font;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 500;
            graphics.ApplyChanges();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tex = Content.Load<Texture2D>("mariosheet2");
            maptex = Content.Load<Texture2D>("wall");

            



            //random
            //b = new Ball_Random(tex, new Vector2(200, 440), Window);
            //gameObjects.Add(b);

           

            map = new Map(maptex, ref gameObjects);
            
            player = new Player(tex, new Vector2(200, 40), new Rectangle(0, 0, 0, 0), Window);
           // gameObjects.Add(player);

           
            
            backgorund.Add(new Background(Content, Window));

            camera = new Camera(player, new Rectangle(0, 0, 500, 500), new Rectangle(0, 0, 500, 1700));
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update();

            //foreach (Platform g in gameObjects)
            //{
            //    if(player.IsColliding(g))
            //    {
            //       player.HandleCollision(g);
            //    }
               
            //}

            

            for (int i = 0; i < gameObjects.Count; i++)
            {

                if ((player as Player).Dir())
                {

                    if (player.isColliding(gameObjects[i]) == true)
                    {
                        //kommentarförattminnas
                        //while (player.PixelCollision(gameObjects[i]))
                        //{

                            player.HandleCollision(gameObjects[i]);
                            collision = true;
                        //}

                    }

                }
            }

            if (collision == false)
            {
                player.setIsonground(false);
            }


            foreach (Background b in backgorund)
            {
                b.Update();
            }

            camera.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.TranslationMatrix);
            //spriteBatch.Begin();
            
            foreach (Background b in backgorund)
            {
                b.Draw(spriteBatch);
            }
            
            map.Draw(spriteBatch, gameObjects);
            player.Draw(spriteBatch);
            
           
            //foreach (Gameobject g in gameObjects)
            //{
            //    g.Draw(spriteBatch);
            //}
            //backgorund.Draw(spriteBatch);
            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
