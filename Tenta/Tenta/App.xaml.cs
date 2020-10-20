using System;
using Tenta.Services;
using Tenta.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tenta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            DependencyService.Register<IApiService, ApiService>();
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
