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
        public Texture2D tex, tex2;
        SpriteBatch sb;
        Player player;
        Vector2 pos;
        public List<string> map = new List<string>();
        //List<Platform> platList = new List<Platform>();
        public Map(Texture2D tex, ref List<Platform> mylist)
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
                    pos = new Vector2(50 * j, 50 * i);

                    if (map[i][j] == 'w')
                    {
                        Platform newMap = new Platform(tex, pos, new Rectangle((int)pos.X, (int)pos.Y, 50, 50));
                        mylist.Add(newMap);
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, List<Platform> myList)
        {
            foreach (Platform w in myList)
            {
                //if(w is Platform)
                w.Draw(spriteBatch);
            }
        }
    }

}




