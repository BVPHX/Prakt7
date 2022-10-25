using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt7
{
    public partial class App : Application
    {
        public static string Key { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
