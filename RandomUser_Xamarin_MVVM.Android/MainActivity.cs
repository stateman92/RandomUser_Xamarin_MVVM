using Android.OS;
using Android.App;
using Android.Runtime;
using Android.Content.PM;

using FFImageLoading.Forms.Platform;

namespace RandomUser_Xamarin_MVVM.Droid
{
    [Activity(Label = "RandomUser_Xamarin_MVVM", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // Neccessary to call in every target in order to the functionality of the library "FFImageLoading".
            CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0, 0));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}