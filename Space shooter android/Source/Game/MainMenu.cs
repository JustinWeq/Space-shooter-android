
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Space_shooter_android.Source.Hud;
using Space_shooter_android.Source._2DGraphics;
using System.Collections.Generic;

namespace Space_shooter_android.Source.Game
{
    class MainMenu
    {
        private Graphic2D title;
        private Button playButton;
        private MainGame parent;
        
        private SoundEffectInstance mainMenuSound;

        public MainMenu(Texture2D playButtonTexture,Texture2D titleTexture,Vector2 screenDimensions,MainGame parent)
        {
            //load the title
            title = new Graphic2D(titleTexture, new Vector2(screenDimensions.X / 20, screenDimensions.Y / 10), new Vector2(screenDimensions.X - (screenDimensions.X / 10),screenDimensions.Y/3));

            //load the button

            playButton = new Button(playButtonTexture, new Vector2(screenDimensions.X / 4, screenDimensions.Y / 2), new Vector2(screenDimensions.X - (screenDimensions.X / 2),screenDimensions.Y/5));

            this.parent = parent;

            //start play the main menu sound
            mainMenuSound = parent.Manager.GameContent.Load<SoundEffect>("Space Adventure").CreateInstance();

            //set main menu sound to looping
            mainMenuSound.IsLooped = true;

            //play main menu sound
            mainMenuSound.Play();

        }

        public void update(List<Vector2> touches)
        {
            //update the button
            playButton.update(touches);

            //check to see if the button is clicked
            if(playButton.Clicked)
            {
                //inform the main game to start playing
                parent.enterGame();
            }
        }

        public void draw(SpriteBatch sprBatch)
        {
            //draw the title
            title.draw(sprBatch);

            //draw the play button
            playButton.draw(sprBatch);
        }
    }
}