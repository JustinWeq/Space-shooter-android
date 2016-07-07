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
namespace Space_shooter_android.Source
{
    
    class TouchHUD
    {
        private Texture2D fireButton;
        private Texture2D joystickHead;
        private Vector2 fireButtonLocation;
        private Vector2 joystickButtonLocation;

        public TouchHUD(GraphicsAdapter adapter,Texture2D fireButton,Texture2D joystickButton)
        {
            //set the buttons location based on the adapter

        }
    }
}