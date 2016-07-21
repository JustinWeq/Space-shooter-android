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
using Space_shooter_android.Source._2DGraphics;
namespace Space_shooter_android.Source.Hud
{
    
    public class TouchHUD
    {
        //private Graphic2D fireButton, joystick;
        private Button button;
        private Joystick joystick;

        public TouchHUD(SpaceGame game,Texture2D fireButton,Texture2D joystickButton)
        {
            //set the buttons location based on the adapter
            int buttonWidth;
            int buttonHeight;
            int buttonX;
            int buttonY;

            //calculate button dimensions based on screen
            buttonWidth = game.Width / 10;

            buttonHeight = game.Height / 10;

            //calculate first buttons position nased on scrren dimensions
            buttonX = buttonWidth;
            buttonY = game.Height- (buttonWidth * 2);

            joystick = new Joystick(new Vector2(buttonWidth,0),joystickButton, new Vector2(buttonX, buttonY), new Vector2(buttonWidth, buttonWidth));

            //calculate second buttons positions based on screen dimensions
            buttonX = game.Width - (buttonWidth * 2);

            button = new Button(fireButton, new Vector2(buttonX, buttonY), new Vector2(buttonWidth, buttonWidth));

        }

        public void update(List<Vector2> touches)
        {
            //update button
            button.update(touches);

            //update joystick
            joystick.update(touches);
        }

        public void draw(SpriteBatch sprBatch)
        {
            //draw the joystick and the button
            joystick.draw(sprBatch);
            button.draw(sprBatch);
        }

        public Vector2 Stick
        {
            get
            {
                return joystick.Stick;
            }
        }
    }
}