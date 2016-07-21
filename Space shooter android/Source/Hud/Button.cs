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
using Space_shooter_android.Source._2DGraphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_shooter_android.Source.Hud
{
    public class Button : Graphic2D
    {
        private bool clicked;

        public bool Clicked
        {
            get
            {
                return clicked;
            }
        }

        public Button(Texture2D texture = null,Vector2 position = new Vector2(),Vector2 dimensions = new Vector2()) : base(texture,position,dimensions)
        {

        }

        public virtual void update(List<Vector2> touches)
        {
            //see if the button is being pressed
            foreach(Vector2 touch in touches)
            {
                //check to see if this is touched
                if ((new Rectangle(position.ToPoint(), dimensions.ToPoint())).Contains(touch))
                {
                    clicked = true;
                    return;
                }
            }
            clicked = false;
            return;
        }
    }
}