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
    public class GameModel : SSAModel
    {
        protected Place place;

        public Place MPlace
        {
            get
            {
                return place;
            }
        }
        public GameModel(Model model,Place place) : base(model)
        {
            this.place = place;
            
        }

        public virtual void update()
        {
            place.update();
        }

        public Vector3 Translation
        {
            get
            {
                return place.Translation;
            }
            set
            {
                place.Translation = value;
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return place.Rotation;
            }
            set
            {
                place.Rotation = value;
            }
        }

        public Vector3 Scale
        {
            get
            {
                return place.Scale;
            }
            set
            {
                place.Scale = value;
            }
        }

        public virtual void draw(Camera camera = null)
        {
            base.draw(place, camera);
        }

        public override void draw(Place place = null, Camera camera = null)
        {
            base.draw(place, camera);
        }

        public bool collides(GameModel other)
        {

            return (model.Meshes[0].BoundingSphere.Intersects(other.model.Meshes[0].BoundingSphere));
        }

    }
}