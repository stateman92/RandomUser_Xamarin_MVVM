using System;
using System.IO;
using System.Linq;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using Plugin.SharedTransitions;

using RandomUser_Xamarin_MVVM.Models;
using RandomUser_Xamarin_MVVM.Services;
using RandomUser_Xamarin_MVVM.ViewModels;
using System.Reflection;

namespace RandomUser_Xamarin_MVVM.Views
{
    public partial class RandomUsersPage : ContentPage
    {

        public RandomUsersPage()
        {
            InitializeComponent();

            BindingContext = new RandomUsersViewModel(new ApiCommunicationService(), new RandomUsersService());
        }

        /// <summary>
        /// After the Button on the Toolbar is clicked, scroll to the top.
        /// </summary>
        /// <remarks>
        /// It's clearly the UI layer's job.
        /// </remarks>
        void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var users = ((RandomUsersViewModel)BindingContext).Users;
            if (users != null && users.Count() > 0)
            {
                listView.ScrollTo(users[0], ScrollToPosition.Start, true);
            }
        }

        /// <summary>
        /// If a row is selected, move to the next page.
        /// </summary>
        /// <remarks>
        /// It's clearly the UI layer's job.
        /// </remarks>
        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var page = new RandomUserDetailsPage();
                var user = e.SelectedItem as User;
                page.BindingContext = user;
                page.Title = $"{user.FullName} ({user.Gender})";
                SharedTransitionNavigationPage.SetTransitionSelectedGroup(this, user.FullName);
                await Navigation.PushAsync(page);
                listView.SelectedItem = null;
            }
        }

        /// <summary>
        /// Make the background image a little bit blurry.
        /// </summary>
        /// <remarks>
        /// It's clearly the UI layer's job.
        /// </remarks>
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
