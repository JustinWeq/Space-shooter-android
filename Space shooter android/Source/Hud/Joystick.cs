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
using Microsoft.Xna.Framework.Graphics;

namespace Space_shooter_android.Source.Hud
{
    public class Joystick : Button
    {
        protected Vector2 maxStretch;
        protected Vector2 startPosition;

        public Vector2 MaxStretch
        {
            get
            {
                return maxStretch;
            }
            set
            {
                maxStretch = value;
            }
        }

        public Joystick(Vector2 maxStretch,Texture2D texture = null, Vector2 position = new Vector2(),Vector2 dimensions = new Vector2()): base(texture,position,dimensions)
        {
            //store the maximum strech distance
            MaxStretch = maxStretch;
            startPosition = position;
        }

        public override void update(List<Vector2> touches)
        {
            base.update(touches);
            if (!Clicked)
            {
                position = startPosition;
            }
            foreach(Vector2 touch in touches)
            {
                if (Math.Pow(startPosition.X - touch.X, 2) < Math.Pow(maxStretch.X, 2))
                {
                    position.X = touch.X;
                }

                if (Math.Pow(startPosition.Y - touch.Y, 2) < Math.Pow(maxStretch.Y, 2))
                {
                    position.Y = touch.Y;
                }
            }
        }

        public Vector2 Stick
        {
            get
            {
                //build stick and return it
                return (new Vector2(
                    (startPosition.X - position.X) / maxStretch.X,
                    (startPosition.Y - position.Y) / maxStretch.Y
                    ));
            }
        }
    }
}