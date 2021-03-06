using DanishDictionary.Services;
using DanishDictionary.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanishDictionary
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<SQLiteDataStore>();
            MainPage = new AppShell();
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
