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

namespace Space_shooter_android.Source._3DGraphics
{
    public class SSAModel
    {
        protected Model model;

        public SSAModel(Model model)
        {

        }

        public virtual void draw(Place place = null,Camera camera = null)
        {
            //draw the current code using the passed in place, if there was not one passed in do not update the basic effects
            if (place != null|| camera != null)
            {
                foreach(ModelMesh mesh in model.Meshes)
                {
                    foreach(BasicEffect effect in mesh.Effects)
                    {
                        effect.World = place.World;
                        
                        if(camera!= null)
                        {
                            effect.Projection = camera.Projection;
                            effect.View = camera.View;
                        }
                    }
                }
            }


           foreach(ModelMesh mesh in model.Meshes)
            {
                //draw the model
                mesh.Draw();
            }

            
        }
    }
}