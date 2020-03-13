using SDR.Models;
using System;
using SDR.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuIniziale : ContentPage
    {
        public MenuIniziale()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lblOperatore.Text = Settings.UserSettings;
            lblVersione.Text = "v. " + SharedData.Version;

            MenuInizialeViewModel vm = new MenuInizialeViewModel();
            //vm.MenuElementi = new Helpers.FullyObservableCollection<VoceMenu>();
            vm.GetMenuElementi();
            BindingContext = vm;
            vm.GetNotificheAsync();
            Device.StartTimer(new TimeSpan(0, 0, 40), () => { vm.GetNotificheAsync(); return true; });

            
        }

        private async void LsMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (lsMenu.SelectedItem != null)
                {
                    var obj = (VoceMenu)e.SelectedItem;
                    switch (obj.Codice)
                    {
                        case "RISTAMPA_ETICHETTE":
                            break;
                        case "LISTA_MOVIMENTI":
                            break;
                        case "LISTA_PRELIEVI":
                            break;
                        case "SMISTAMENTO_PRELIEVO":
                            break;
                        case "INFO_ARTICOLO_PRELEVATO":
                            break;
                        case "INFO_ARTICOLO_POSIZIONE":
                            break;
                        case "NUOVA_POSIZIONE":
                            break;
                        case "INVENTARIO":
                            break;
                        case "UBICAZIONI_VUOTE":
                            break;
                        case "UTILITA":
                            break;
                        case "ETICHETTE_VUOTE":

                            break;

                        default:
                            break;
                    }

                    lsMenu.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                var err = ex.ToString();
            }
        }

        
    }
}