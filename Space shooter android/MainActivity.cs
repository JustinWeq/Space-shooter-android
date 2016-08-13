using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using System.IO;

namespace Space_shooter_android
{
    [Activity(Label = "Space shooter android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.SensorLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class MainActivity : Microsoft.Xna.Framework.AndroidGameActivity
    {

        private static MainActivity instance = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var g = new SpaceGame();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();
            instance = this;
        }

        public static MainActivity getInstance()
        {
            return instance;
        }

        public string readTxtFromAssets(string filePath)
        {
            using (StreamReader read = new StreamReader(Assets.Open(filePath)))
            {
                return read.ReadToEnd();
            }

        }
    }
}

