using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mario
{
    public enum gamestate
    {
        Menu,
        Paused,
        Playing,
        Loss,
        Victory,
    }
    class Gamemanager
    {
        Texture2D tex, maptex, enemyTex, princess, life, cointex;
        Vector2 scorePos, lifePos, heartPos;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameWindow gameWindow;
        GraphicsDevice graphicsDevice;
        ContentManager Content;


        SpriteFont scorefont;
        SpriteFont lifefont;
        KeyboardState oldks, ks;
        List<Background> backgorund = new List<Background>();
        List<Platform> platforms = new List<Platform>();
        List<Enemy> enemies = new List<Enemy>();
        List<JumpBoost> boost = new List<JumpBoost>();
        List<Coin> coins = new List<Coin>();
        List<Trap> trap = new List<Trap>();

        Player player;
        Goal goal;

        Map map;
        Camera camera;


        public static int Score = 0;
        public static int Lives = 3;

        bool collision;

        public static Texture2D hitboxChecker;

        gamestate state = gamestate.Menu;

        public Gamemanager(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, GameWindow gameWindow, GraphicsDevice graphicsDevice)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
            this.gameWindow = gameWindow;
            this.graphicsDevice = graphicsDevice;
        }

        public void LoadContent(ContentManager Content)
        {
           // spriteBatch = new SpriteBatch(graphicsDevice);
            tex = Content.Load<Texture2D>("mariosheet2");
            maptex = Content.Load<Texture2D>("wall");
            enemyTex = Content.Load<Texture2D>("Sheet_Platt");
            hitboxChecker = Content.Load<Texture2D>("hit");
            princess = Content.Load<Texture2D>("goal3");
            life = Content.Load<Texture2D>("life2");
            cointex = Content.Load<Texture2D>("Coin");

            scorefont = Content.Load<SpriteFont>("scorefont");
            lifefont = Content.Load<SpriteFont>("lifefont"); ;
            map = new Map(maptex, ref platforms);


            player = new Player(tex, map.GetPlayerPosition()[0]);
            goal = new Goal(princess, map.GetGoalPosition()[0]);
            //backgorund.Add(new Background(Content, Window));
            backgorund.Add(new Background(Content, gameWindow));
            camera = new Camera(player);

            lifePos.X = player.GetPos().X;
            lifePos.Y = 0;

            scorePos.X = player.GetPos().X;
            scorePos.Y = 0;

            heartPos.X = player.GetPos().X;
            heartPos.Y = 0;

            ObjectLists();
        }

        public void Update(GameTime gameTime)
        {
            oldks = ks;
            ks = Keyboard.GetState();
            switch (state)
            {
                case gamestate.Menu:
                    if (ks.IsKeyDown(Keys.Enter))
                        state = gamestate.Playing;
                    break;
                case gamestate.Paused:
                    if (ks.IsKeyDown(Keys.P) && oldks.IsKeyUp(Keys.P))
                        state = gamestate.Playing;
                    break;
                case gamestate.Playing:
                    PlayingFunction(gameTime);
                    break;
                case gamestate.Loss:
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        state = gamestate.Playing;
                        RestartGame();
                    }
                    break;
                case gamestate.Victory:
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        state = gamestate.Playing;
                        RestartGame();
                    }
                    break;
                default:
                    break;
            }
        }

        public void Draw(GameTime gameTime)
        {
            {
                //GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.TranslationMatrix);
                switch (state)
                {
                    case gamestate.Paused:
                        DrawPlaying();
                        break;
                    case gamestate.Playing:
                        DrawPlaying();
                        break;
                    default:
                        break;
                }
                spriteBatch.End();
                //base.Draw(gameTime);
            }
        }

        void ObjectLists()
        {
            foreach (Vector2 v in map.GetEnemyPositions())
            {
                enemies.Add(new Enemy(enemyTex, v));
            }

            foreach (Vector2 c in map.GetCoinPositions())
            {
                coins.Add(new Coin(cointex, c));
            }

            foreach (Vector2 b in map.GetBoostPosition())
            {
                boost.Add(new JumpBoost(maptex, b));
            }

            foreach (Vector2 t in map.GetTrapPositions())
            {
                trap.Add(new Trap(maptex, t));
            }
        }

        public void CheckCollision(GameTime gameTime)
        {
            {
                ks = Keyboard.GetState();
                collision = false;
                EnemyCollision(gameTime);
                PlayerCollision();
                BoostCollision();
                CoinCollision(gameTime);

                if (collision == false)
                {
                    player.setIsonground(false);
                }
            }
        }

        void BoostCollision()
        {

            foreach (JumpBoost b in boost)
            {

                if (player.hitBox.Intersects(b.killHitBox))
                {
                    //if (ks.IsKeyDown(Keys.Space))
                    player.SetSpeed(-15);
                }
            }
        }
        void PlayerCollision()
        {
            for (int i = 0; i < platforms.Count; i++)
            {

                if (player.isColliding(platforms[i]) == true)
                {
                    player.HandleCollision(platforms[i]);
                    collision = true;
                }
            }
            for (int i = 0; i < boost.Count; i++)
            {
                if (player.isColliding(boost[i]) == true)
                {
                    player.HandleCollision(boost[i]);
                    collision = true;
                }
            }
        }
        void CoinCollision(GameTime gameTime)
        {
            foreach (Coin c in coins)
            {
                c.Update(gameTime, 50);
                if (player.hitBox.Intersects(c.hitBox))
                {
                    Score = Score + 100;
                    coins.Remove(c);
                    break;
                }
            }
        }
        void EnemyCollision(GameTime gameTime)
        {
            foreach (Enemy e in enemies)
            {
                e.Update(gameTime, 0);
                for (int i = 0; i < platforms.Count; i++)
                {
                    if (e.isColliding(platforms[i]) == true)
                    {
                        e.HandleCollision(platforms[i]);
                    }
                }
                for (int i = 0; i < boost.Count; i++)
                {
                    if (e.isColliding(boost[i]) == true)
                    {
                        e.HandleCollision(boost[i]);
                    }
                }

                if (player.hitBox.Intersects(e.killHitBox))
                {
                    player.SetSpeed(-11);
                    Score = Score + 50;
                    enemies.Remove(e);
                    break;
                }
                if (player.isColliding(e) == true)
                {
                    if (player.PixelCollision(e) == true)
                    {
                        Lives--;
                        Score = Score - 200;
                        player.resetPosition();
                    }
                }
            }
        }

        void PlayingFunction(GameTime gameTime)
        {
            if (ks.IsKeyDown(Keys.P) && oldks.IsKeyUp(Keys.P))
                state = gamestate.Paused;
            if (Lives < 0)
            {
                state = gamestate.Loss;
            }

            if (player.isColliding(goal))
            {
                state = gamestate.Victory;
            }

            player.Update(gameTime, 0);
            CheckCollision(gameTime);

            foreach (Background b in backgorund)
            {
                b.Update();
            }

            scorePos.X = player.GetPos().X - 400;
            scorePos.Y = 0;

            lifePos.X = player.GetPos().X - 368;
            lifePos.Y = 65;

            heartPos.X = player.GetPos().X - 390;
            heartPos.Y = 50;
            camera.Update();
        }
        void RestartGame()
        {
            enemies.Clear();
            coins.Clear();
            boost.Clear();
            Score = 0;
            Lives = 3;
            player.resetPosition();
            ObjectLists();
        }
        void DrawPlaying()
        {

            foreach (Background b in backgorund)
            {
                b.Draw(spriteBatch);
            }
            foreach (Enemy e in enemies)
            {
                e.Draw(spriteBatch);
            }
            map.Draw(spriteBatch, platforms);
            player.Draw(spriteBatch);
            goal.Draw(spriteBatch);
            foreach (JumpBoost b in boost)
            {
                b.Draw(spriteBatch);
            }
            foreach (Coin c in coins)
            {
                c.Draw(spriteBatch);
            }

            foreach (Trap t in trap)
            {
                t.Draw(spriteBatch);
            }
            spriteBatch.Draw(life, heartPos, Color.White);
            spriteBatch.DrawString(scorefont, "Score: " + Score, scorePos, Color.White);
            spriteBatch.DrawString(lifefont, "" + Lives, lifePos, Color.White);
        }
    }
}
