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

namespace Space_shooter_android.Source
{
    public class Place
    {
        protected Matrix world;
        protected Vector3 translation;
        protected Vector3 scale;
        protected Vector3 rotation;

        public Place(Vector3 translation = new Vector3(),Vector3 rotation = new Vector3(),Vector3 scale = new Vector3())
        {
            this.translation = translation;
            this.rotation = rotation;
            this.scale = scale;
        }

        public virtual void update()
        {
            //update the world matrix

            world = Matrix.CreateScale(scale)*Matrix.CreateFromYawPitchRoll(rotation.X,rotation.Y,rotation.Z)* Matrix.CreateTranslation(translation);
        }

        public Matrix World
        {
            //return world
            get
            {
                return world;
            }
            set
            {
                world = value;
            }
        }

        public Vector3 Translation
        {
            get
            {
                return translation;
            }
            set
            {
                translation = value;
            }
        }

        public Vector3 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }

    }
}