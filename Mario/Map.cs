using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario
{
    class Map
    {
        public List<string> map = new List<string>();
        List<Gameobject> gameObjects = new List<Gameobject>();
        
        public Map(Texture2D tex, ref List<Platform> PlatList)
        {
            StreamReader mapStr = new StreamReader(@"bana.txt");
            while (!mapStr.EndOfStream)
            {
                map.Add(mapStr.ReadLine());

            }
            mapStr.Close();


            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'w')
                    {
                        Platform newMap = new Platform(tex, new Vector2(50 * j, 50 * i), new Rectangle((int)50 * j, (int)50 * i, 50, 50));
                        PlatList.Add(newMap);
                    }
                }
            }
        }

        public List<Vector2> GetEnemyPositions()
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'e' || map[i][j] == 'E')
                    {
                        result.Add(new Vector2(50 * j, 50 * i));
                        
                    }

                }
            }
            return result;
        }
        public List<Vector2> GetPlayerPosition()
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'm' || map[i][j] == 'M')
                    {
                        result.Add(new Vector2(50 * j, 50 * i));

                    }

                }
            }
            return result;
        }
        public List<Vector2> GetGoalPosition()
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'P' || map[i][j] == 'p')
                    {
                        result.Add(new Vector2(50 * j, 50 * i));

                    }

                }
            }
            return result;
        }
        public List<Vector2> GetBoostPosition()
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'J' || map[i][j] == 'j')
                    {
                        result.Add(new Vector2(50 * j, 50 * i));

                    }

                }
            }
            return result;
        }
        public List<Vector2> GetCoinPositions()
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'C' || map[i][j] == 'c')
                    {
                        result.Add(new Vector2(50 * j, 50 * i));

                    }

                }
            }
            return result;
        }

        public List<Vector2> GetTrapPositions()
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'T' || map[i][j] == 't')
                    {
                        result.Add(new Vector2(50 * j, 50 * i));

                    }

                }
            }
            return result;
        }
        public void Draw(SpriteBatch spriteBatch, List<Platform> myList)
        {
            foreach (Platform p in myList)
            {
                p.Draw(spriteBatch);
            }
        }
    }

}




