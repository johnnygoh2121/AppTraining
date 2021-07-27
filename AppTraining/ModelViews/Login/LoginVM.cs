using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTraining.ModelViews.Login
{
    public class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CmdLogin { get; set; }

        string _userId { get; set; }
        public string userId
        {
            get => _userId;
            set
            {
                if (_userId == value) return;
                _userId = value;
                OnPropertyChanged(nameof(userId));
            }
        }

        string _pw { get; set; }
        public string pw
        {
            get => _pw;
            set
            {
                if (_pw == value) return;
                _pw = value;
                OnPropertyChanged(nameof(pw));
            }
        }

        string _btnTextDisplay { get; set; } // internal usage 
        public string btnTextDisplay // refresh UI
        {
            get => _btnTextDisplay;
            set
            {
                if (_btnTextDisplay == value) return;
                _btnTextDisplay = value;
                OnPropertyChanged(nameof(btnTextDisplay));
            }
        }

        bool _IsSaveBusy { get; set; } = false;

        protected void OnPropertyChanged(string proName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proName));

        INavigation Navigation { get; set; }
        
        public LoginVM (INavigation navigation)
        {
            Navigation = navigation;
            InitCmds();
            btnTextDisplay = "Testing testing";
            userId = "Johnny";
            pw = "1234";
        }

        void InitCmds()
        {
            CmdLogin = new Command(
                            execute: () =>
                            {
                                // Peform save
                                Save();

                            }, canExecute: () =>
                            {
                                return !_IsSaveBusy;
                            });
        }

        void Save ()
        {
            try
            {
                if (_IsSaveBusy) return;
                _IsSaveBusy = true;

                // prompt a diaply alert 
                // do u confirm save / delete / remove 



                // process what u wan to do 
            }
            catch (Exception e)
            {

            }
            finally
            {
                _IsSaveBusy = false;
            }
        }
    }
}
