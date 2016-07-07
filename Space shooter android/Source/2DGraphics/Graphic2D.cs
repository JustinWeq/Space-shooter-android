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

namespace Space_shooter_android.Source._2DGraphics
{
    public class Graphic2D
    {
        private Texture2D texture;
        protected Vector2 position;
        protected Vector2 dimensions;
        
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public Vector2 Dimensions
        {
            get
            {
                return dimensions;
            }
            set
            {
                dimensions = value;
            }
        }

        public Graphic2D(Texture2D texture = null, Vector2 position = new Vector2(),Vector2 dimensions = new Vector2())
        {
            this.position = position;
            this.texture = texture;
            this.dimensions = dimensions;
        }

        public virtual void draw(SpriteBatch sprBatch)
        {
            sprBatch.Draw(texture, new Rectangle(position.ToPoint(), dimensions.ToPoint()), Color.White);
        }
    }
}