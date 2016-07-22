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

namespace Space_shooter_android.Source._3DGraphics
{
    public class SSAModel
    {
        protected Model model;

        protected float radius;

        public float Radius
        {
            get
            {
                return radius;
            }
        }

        protected float alpha;

        public float Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;
            }
        }

        public SSAModel(Model model)
        {
            alpha = 1f;

            this.model = model;

            //get the radius of the model for collision
            radius = model.Meshes[0].BoundingSphere.Radius;

        }

        public virtual void draw(Place place = null,Camera camera = null)
        {
            //check to see if the alpha is less then 0 and if it is do not draw the model
            if (alpha < 0f)
                return;

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    effect.PreferPerPixelLighting = true;
                    //test

                    effect.World = place.World; //Matrix.CreateRotationX(MathHelper.Pi / 2);

                    Vector3 cameraPos = new Vector3(0, 19, 0);

                    Vector3 cameraLookAt = Vector3.Zero;

                    Vector3 cameraUpVector = Vector3.UnitZ;

                    effect.View = camera.View;//Matrix.CreateLookAt(cameraPos, cameraLookAt, cameraUpVector);

                    effect.Projection = camera.Projection;

                    effect.Alpha = alpha;

                    //effect.Texture = redCube;
                    //effect.TextureEnabled = true;
                }

                mesh.Draw();
            }


        }
    }
}