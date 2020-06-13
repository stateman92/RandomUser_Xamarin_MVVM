using System.IO;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Reflection;

namespace RandomUser_Xamarin_MVVM.Views
{
    public partial class RandomUserDetailsPage : ContentPage
    {
        public RandomUserDetailsPage()
        {
            InitializeComponent();
        }
        /*
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var surface = args.Surface;
            var canvas = surface.Canvas;

            var snap = surface.Snapshot();

            Stream fileStream = File.OpenRead("background.jpg");

            canvas.DrawColor(SKColors.Black);

            using var stream = new SKManagedStream(fileStream);
            using var bitmap = SKBitmap.Decode(stream);
            using var paint = new SKPaint();
            using var filter = SKImageFilter.CreateBlur(10, 10);
            paint.ImageFilter = filter;
            canvas.DrawBitmap(bitmap, SKRect.Create(snap.Width, snap.Height), paint);
        }*/

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var surface = args.Surface;
            var canvas = surface.Canvas;

            var snap = surface.Snapshot();

            Assembly assembly = GetType().GetTypeInfo().Assembly;

            Stream stream = assembly.GetManifestResourceStream("RandomUser_Xamarin_MVVM.background.jpg");

            canvas.DrawColor(SKColors.Black);

            using var bitmap = SKBitmap.Decode(stream);
            using var paint = new SKPaint();
            using var filter = SKImageFilter.CreateBlur(10, 10);
            paint.ImageFilter = filter;
            canvas.DrawBitmap(bitmap, SKRect.Create(snap.Width, snap.Height), paint);
        }
    }
}
