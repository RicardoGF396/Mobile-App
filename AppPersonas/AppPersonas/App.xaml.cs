using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPersonas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Permite navegación
            MainPage = new NavigationPage (new MainPage());
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
