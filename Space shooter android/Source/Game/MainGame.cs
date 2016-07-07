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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Space_shooter_android.Source
{
    public class MainGame
    {
        private TouchHUD hud;
        private Game manager;

        public Game Manager
        {
            get
            {
                return manager;
            }
        }

        public MainGame(Game game)
        {
            //start the game by settings up the hud
            manager = game;

            //load the hud
            hud = new TouchHUD(manager.graphicsAdapter, manager.Content.Load<Texture2D>("FireButton.png"), manager.Content.Load<Texture2D>("Joystick.png"));

        }

        public void update(GameTime time)
        {
            //update the hud
        }

        public void draw(SpriteBatch batch)
        {
            batch.Begin();
            //draw the hud
            hud.draw(batch);

            batch.End();
        }



    }
}