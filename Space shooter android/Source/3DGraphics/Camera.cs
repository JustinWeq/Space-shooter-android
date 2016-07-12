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


namespace Space_shooter_android.Source._3DGraphics
{
    public class Camera
    {
        private Matrix view;
        private Matrix projection;

        public Matrix View
        {
            get
            {
                return view;
            }
        }


        public Matrix Projection
        {
            get
            {
                return projection;
            }
        }
        public Camera(int screenWidth,int screenHeight)
        {
            //create the projection matrix

            float aspectRatio = screenWidth / (float)screenHeight;

            float fieldOfView = MathHelper.PiOver4;

            float nearClipPane = 1;

            float farClipPane = 200;
            projection = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearClipPane, farClipPane);

            //update view

            updateView();
        }

        public void updateView(Vector3 lookAt  =new Vector3(),Vector3 lookFrom = new Vector3())
        {
            //update the camera

            view = Matrix.CreateLookAt(lookFrom, lookAt, Vector3.UnitZ);
        }
    }
}