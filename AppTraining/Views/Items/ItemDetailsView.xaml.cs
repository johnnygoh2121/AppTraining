using AppTraining.Models.Item;
using AppTraining.ModelViews.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTraining.Views.Items
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailsView : ContentPage
    {
        ItemDetailsVM ViewModel;
        public ItemDetailsView(OITM selectedItem)
        {
            InitializeComponent();
            ViewModel = new ItemDetailsVM(Navigation, selectedItem);
            BindingContext = ViewModel;

            //BindingContext = new ItemDetailsVM(selectedItem);
        }

        private void Closed_Cliked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}