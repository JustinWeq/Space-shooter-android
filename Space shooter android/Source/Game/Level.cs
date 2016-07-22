using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using System.IO;

namespace Space_shooter_android.Source.Game
{
    class Level
    {
        private float maxDistance;

        public float MaxDistance
        {
            get
            {
                return maxDistance;
            }
        }

        public Level(string levelFileName)
        {
            //load the level by openeing a title container string
            using (Stream levelStream = TitleContainer.OpenStream("Level1.lvl"))
            {
                using (StreamReader reader = new StreamReader(levelStream))
                {
                    string[] args;
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        args = line.Split(' ');
                        switch(args[0])
                        {
                            case "maxDistance":
                                {
                                    maxDistance = float.Parse(args[1]);
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}