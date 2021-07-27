using AppTraining.Models.Item;
using AppTraining.Views.Items;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppTraining.ModelViews.Items
{
    public class ItemListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string proName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proName));

        INavigation Navigation { get; set; }

        OITM _SelectedItem { get; set; }
        public OITM SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (_SelectedItem == value) return;
                _SelectedItem = value;

                HandlerSelectedItem(value);

                //Navigation.PushAsync(new ItemDetailsView(value));

                // halder the selected item
                //_SelectedItem = null;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        List<OITM> _ItemsSource { get; set; }

        public ObservableCollection<OITM> ItemsSource { get; set; }

        // constructor 
        public ItemListVM (INavigation navigation)
        {
            Navigation = navigation;
            LoadItems();
        }

        async void HandlerSelectedItem (OITM selectedItem)
        {
            try
            {
                // messaging center demo 
                var address = "any_name_in_string_which_is_unique_in_this_App_xxxx9999";
                MessagingCenter.Subscribe(this, address, (string data) => 
                {
                    MessagingCenter.Unsubscribe<string>(this, address);

                    if (data == null) return;
                    if (string.IsNullOrWhiteSpace($"{data}")) return;

                    // do something after received the event 
                    StartTimerProces_xx(data);
                    return;
                });

                await Navigation.PushAsync(new ItemDetailsView(selectedItem, address));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        void StartTimerProces_xx (string data)
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 120), () =>
                {
                    // Start mew process to the item;
                    ProcessData(data);
                    return true;
                });
        }

        void ProcessData(string data)
        {
            // process the data let the pre process close
        }

        void LoadItems ()
        {
            try
            {
                var client = new RestClient("http://192.168.68.108:45455/Item");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                var body = new { request = "items" };
                var json = JsonConvert.SerializeObject(body);

                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if (response == null)
                {
                    return;
                }

                var content = response.Content;
                if (!string.IsNullOrWhiteSpace(content))
                {
                    _ItemsSource = JsonConvert.DeserializeObject<List<OITM>>(content);
                    Rebind(_ItemsSource);
                }
            }
            catch (Exception e)
            {

            }
        }

        void Rebind (List<OITM> list)
        {
            if (list == null) return;
            ItemsSource = new ObservableCollection<OITM>(list);
            OnPropertyChanged(nameof(list));
        }

    }
}
