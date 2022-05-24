using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectTsybirevV4
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProjectTsybirevV4.MainPage())
            {
                BarBackgroundColor = Color.Coral
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
