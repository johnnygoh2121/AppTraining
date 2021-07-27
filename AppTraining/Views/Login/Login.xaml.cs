using AppTraining.ModelViews.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTraining.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        LoginVM ViewModel;

        public Login()
        {
            InitializeComponent();
            ViewModel = new LoginVM(Navigation);
            BindingContext = ViewModel;
        }

        private void loginTapped(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Login tapped", "OK");
        }
    }
}