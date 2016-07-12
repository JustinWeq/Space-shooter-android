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

        public SSAModel(Model model)
        {
            this.model = model;
        }

        public virtual void draw(Place place = null,Camera camera = null)
        {
            // //draw the current code using the passed in place, if there was not one passed in do not update the basic effects
            // if (place != null|| camera != null)
            // {
            //     foreach(ModelMesh mesh in model.Meshes)
            //     {

            //         foreach(BasicEffect effect in mesh.Effects)
            //         {
            //             effect.World = Matrix.CreateRotationX(MathHelper.Pi / 2); ;
            //             if(camera!= null)
            //             {
            //                 effect.Projection = camera.Projection;
            //                 effect.View = camera.View;
            //             }
            //         }
            //     }
            // }


            //foreach(ModelMesh mesh in model.Meshes)
            // {
            //     //draw the model
            //     mesh.Draw();
            // }

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

                    float aspectRatio = 1280 / (float)720;

                    float fieldOfView = MathHelper.PiOver4;

                    float nearClipPane = 1;

                    float farClipPane = 200;

                    effect.Projection = camera.Projection;

                    //effect.Texture = redCube;
                    //effect.TextureEnabled = true;
                }

                mesh.Draw();
            }


        }
    }
}