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
    public class Player : GameModel
    {
        protected Vector2 force;
        public Player(Model model,Place place,Vector2 force = new Vector2()) : base(model,place)
        {
            this.force = force;
        }

        public Vector2 Force
        {
            get
            {
                return force;
            }
            set
            {
                force = value;
            }
        }

        public override void update()
        {
            //update the new translation
            place.Translation = new Vector3((float)Math.Cos(Direction) *Magnitude,0,(float)Math.Sin(Direction) * Magnitude);
            place.Rotation = new Vector3(MathHelper.PiOver2, Direction, 0);
            place.Scale = Vector3.One;
            base.update();

        }
        public float Direction
        {
            get
            {
                return force.X;
            }
            set
            {
                force.X = value;
            }
        }

        public float Magnitude
        {
            get
            {
                return force.Y;
            }
            set
            {
                force.Y = value;
            }
        }
    }
}