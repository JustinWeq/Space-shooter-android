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
using Space_shooter_android.Source._3DGraphics;

namespace Space_shooter_android.Source.Game
{
    public class MainGame
    {
        private TouchHUD hud;
        private SpaceGame manager;
        private Player player;
        private Camera camera;

        public SpaceGame Manager
        {
            get
            {
                return manager;
            }
        }

        public MainGame(SpaceGame game)
        {
            //start the SpaceGame by settings up the hud
            manager = game;

            //load the hud
            hud = new TouchHUD(game, manager.GameContent.Load<Texture2D>("FireButton"), manager.Content.Load<Texture2D>("Joystick"));

            player = new Player(manager.GameContent.Load<Model>("PlayerShip"), new Place());

            player.Magnitude = 2f;

            //set up the camera to have it look at the player
            camera = new Camera(game.Width,game.Height);
        }

        public void update(GameTime time)
        {
            //update the hud
            //update the player
            player.update();

            //update the cameras view
            camera.updateView(player.Translation, new Vector3(1,1,19));
        }

        public void draw(SpriteBatch batch)
        {
            manager.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            //draw the player
            player.draw(camera);

            batch.Begin();
            //draw the hud
            hud.draw(batch);
            batch.End();

            
        }



    }
}