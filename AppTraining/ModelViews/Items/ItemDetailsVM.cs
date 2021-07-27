using AppTraining.Models.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTraining.ModelViews.Items
{
    public class ItemDetailsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ICommand CmdClose { get; set; }
        public ICommand CmdClose3 { get; set; }

        public OITM CurItem { get; set; }

        public string ItemCode { get; set; }

        INavigation Navigation { get; set; }

        // constructor
        public ItemDetailsVM(INavigation navigation, OITM selectedItem)
        {
            try
            {
                Navigation = navigation;
                CurItem = selectedItem;
                ItemCode = CurItem.ItemCode;

                ItemCode = ",,,,";

                InitCmds();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void InitCmds ()
        {
            CmdClose = new Command(() =>
            {
                Navigation.PopAsync();
            });

            CmdClose3 = new Command<string>( (string param) =>
            {
                Navigation.PopAsync();
            });

        }
    }
}
