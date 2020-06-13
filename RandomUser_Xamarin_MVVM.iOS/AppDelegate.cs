using UIKit;
using Foundation;

using FFImageLoading.Forms.Platform;
using Lottie.Forms.iOS.Renderers;

namespace RandomUser_Xamarin_MVVM.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            // Neccessary to call in every target in order to the functionality of the library "FFImageLoading".
            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();

            // Neccessary to call in every target in order to the functionality of the library "Lottie".
            AnimationViewRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}
