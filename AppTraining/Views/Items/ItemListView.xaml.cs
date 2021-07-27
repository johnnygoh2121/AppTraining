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
    public partial class ItemListView : ContentPage
    {
        ItemListVM ViewModel;

        public ItemListView()
        {
            InitializeComponent();
            ViewModel = new ItemListVM(Navigation);

            BindingContext = ViewModel;
        }
    }
}