using SDR.Helpers;
using SDR.Models;
using SDR.ViewModels;
using SDR.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public string ContextUser
        {
            get { return Settings.UserSettings; }
            set
            {
                if (Settings.UserSettings == value)
                    return;
                Settings.UserSettings = value;
                OnPropertyChanged();
            }
        }

        public string ContextUserOperatore
        {
            get { return Settings.UserOperatoreSettings; }
            set
            {
                if (Settings.UserOperatoreSettings == value)
                    return;
                Settings.UserOperatoreSettings = value;
                OnPropertyChanged();
            }
        }


        public Login(string codiceUtente)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var r = GetuUtentiAsync(codiceUtente);
        }

        async Task GetuUtentiAsync( string codiceUtente)
        {

            loader.IsRunning = true;
            loader.IsVisible = true;
            lblLoader.IsVisible = true;

            UtenteViewModel _viewmodel = new UtenteViewModel();
            await _viewmodel.GetUtentiAsync();

            BindingContext = _viewmodel;

            if (_viewmodel.Utenti is null) _viewmodel.Utenti = new System.Collections.ObjectModel.ObservableCollection<Utente>();

            if (!string.IsNullOrEmpty(codiceUtente))
            {
                foreach (var u in _viewmodel.Utenti)
                {
                    if (u.CodiceUtente == codiceUtente)
                    {
                        picker.SelectedItem = u;
                        break;
                    }
                }
            } 

            lblLoader.IsVisible = false;
            loader.IsRunning = false;
            loader.IsVisible = false;

        }


        private async void OnBtnAvantiClick(object sender, EventArgs e)
        {

          
            if (picker.SelectedIndex >= 0)
            {
                Utente ute = ((Utente)picker.SelectedItem);
                ContextUser = ute.CodiceUtente;
                ContextUserOperatore = ute.CodiceOperatore;
                await Navigation.PushAsync(new MenuIniziale());
            }
        }
    }
}