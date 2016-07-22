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
using Space_shooter_android.Source._3DGraphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Space_shooter_android.Source.Game
{
    class FadeEffectModel : GameModel
    {
        private GameModel parent;
        private float fade;

        public float Fade
        {
            set
            {
                fade = value;
            }
        }

        public FadeEffectModel(GameModel parent,Model model ):base(model,new Place())
        {
            fade = 1;
            this.parent = parent;

        }

        public override void update()
        {
            //set the translation and rotation accordingly
            place = new Place(parent.Translation, parent.Rotation, new Vector3(radius, radius, radius));
            
            fade = (fade=+1f/60f) > 1? 1 : fade;

            alpha = 1f-fade;
            base.update();
        }


    }
}