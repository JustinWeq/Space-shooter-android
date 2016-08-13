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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Space_shooter_android.Source.Game
{
    public class Enemy : GameModel
    {
        protected float health;
        protected float speed;
        protected bool collides;
        public Enemy(string[] lines,ref int position): base(null,null)
        {
            //start reading the lines
            float x=0, y=0;
            float depth = 0;
            collides = false;
            health = 0;
            speed = 0;
            string[] args = lines[position].Split(' ');
            while (args[0] != "end")
            {
                switch (args[0])
                {
                    case "position":
                        {
                            x = float.Parse(args[1]);
                            y = float.Parse(args[2]);
                            break;
                        }
                    case "depth":
                        {
                            depth = float.Parse(args[1]);
                            break;
                        }
                    case "health":
                        {
                            health = float.Parse(args[1]);
                            break;
                        }
                    case "speed":
                        {
                            speed = float.Parse(args[1]);
                            break;
                        }
                    case "model":
                        {
                            model = SpaceGame.manager.Load<Model>(args[1]);
                            break;
                        }
                }
                args = lines[++position].Split(' ');
            }
            place = new Place(new Vector3(x, y, depth), Vector3.Zero, Vector3.One);


        }

        
    }
}