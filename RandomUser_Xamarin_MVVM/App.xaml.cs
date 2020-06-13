using Xamarin.Forms;

using Plugin.SharedTransitions;

using RandomUser_Xamarin_MVVM.Views;

namespace RandomUser_Xamarin_MVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SharedTransitionNavigationPage(new RandomUsersPage())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
