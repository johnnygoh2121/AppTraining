using AppTraining.Models.Item;
using AppTraining.ModelViews.Items;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTraining.Views.Items
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailsView : ContentPage
    {
        ItemDetailsVM ViewModel;
        public ItemDetailsView(OITM selectedItem, string repliedAddress)
        {
            InitializeComponent();
            ViewModel = new ItemDetailsVM(Navigation, selectedItem, repliedAddress);
            BindingContext = ViewModel;

            //BindingContext = new ItemDetailsVM(selectedItem);
        }

        private void Closed_Cliked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}