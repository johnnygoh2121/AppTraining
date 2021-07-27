using AppTraining.Views.Items;
using AppTraining.Views.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTraining
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new Login();

            MainPage =  new NavigationPage( new ItemListView());
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
