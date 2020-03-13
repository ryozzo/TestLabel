using SDR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using SDR.Helpers;

namespace SDR
{
    public class MenuInizialeViewModel : BaseViewModel
    {
      
        private FullyObservableCollection<VoceMenu> _menuElementi;

        public FullyObservableCollection<VoceMenu> MenuElementi
        {
            get { return _menuElementi; }
            set
            {
                _menuElementi = value;
                OnPropertyChanged("MenuElementi");
            }
        }
        

        public MenuInizialeViewModel()
        {
            
        }

        public void GetMenuElementi()
        {
            List<VoceMenu> ls = new List<VoceMenu>();
            ls.Add(new VoceMenu("LISTA_PRELIEVI", "PRELIEVO", 0));
            ls.Add(new VoceMenu("SMISTAMENTO_PRELIEVO", "SMISTAMENTO ULTIMO PRELIEVO", 0 ));
            ls.Add(new VoceMenu("INFO_ARTICOLO_PRELEVATO", "INTERROGAZIONE PRELIEVI", 0 ));
            ls.Add(new VoceMenu("LISTA_MOVIMENTI", "CHIUSURA", 0));
            ls.Add(new VoceMenu("RISTAMPA_ETICHETTE", "ETICHETTE CHIUSURA", 0));
            ls.Add(new VoceMenu("NUOVA_POSIZIONE", "NUOVA POSIZIONE", 0));
            ls.Add(new VoceMenu("INFO_ARTICOLO_POSIZIONE", "POSIZIONAMENTO", 0));
            ls.Add(new VoceMenu("INVENTARIO", "INVENTARIO", 0));
            ls.Add(new VoceMenu("UBICAZIONI_VUOTE", "UBICAZIONI VUOTE", 0));
            ls.Add(new VoceMenu("ETICHETTE_VUOTE", "ETICHETTE VUOTE", 0));
            ls.Add(new VoceMenu("UTILITA", "UTILITA", 0));

            MenuElementi = new FullyObservableCollection<VoceMenu>(ls);
            MenuElementi.CollectionChanged += MenuElementiChanged;
            MenuElementi.ItemPropertyChanged += MenuElementiItemChanged;
        }

        public async void GetNotificheAsync()
        {
            IsBusy = true;
            try
            {
                for (int i = 0; i < MenuElementi.Count - 1; i++)
                {

                    string tipo = "";
                    if (MenuElementi[i].Codice == "LISTA_PRELIEVI") tipo = "PRELIEVO";
                    if (MenuElementi[i].Codice == "LISTA_MOVIMENTI") tipo = "CHIUSURA";
                    if (string.IsNullOrEmpty(tipo)) continue;

                    EnvelopResponse resp = null;
                    string resultContent = "";

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Settings.UrlSettings);
                        var content = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("CodiceUtente", Settings.UserSettings),
                            new KeyValuePair<string, string>("Tipo", tipo)
                        });
                        var result = await client.PostAsync("/Integrazioni/GetNumeroAssegnazioni", content);
                        resultContent = await result.Content.ReadAsStringAsync();
                    }

                    if (!string.IsNullOrEmpty(resultContent)) resp = JsonConvert.DeserializeObject<EnvelopResponse>(resultContent);

                    if (resp != null)
                    {

                        NotificaResult docs = JsonConvert.DeserializeObject<NotificaResult>(resp.data.ToString());
                        var nuovo = new VoceMenu(MenuElementi[i].Codice, MenuElementi[i].Descrizione, docs.NumeroNotifica);
                        MenuElementi.RemoveAt(i);
                        MenuElementi.Insert(i,nuovo);


                    }

                }


            }
            catch (Exception ex)
            {
                var errore = ex.StackTrace.ToString();

            }
            finally
            {
                IsBusy = false;
            }
        }



        protected void MenuElementiChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("MenuElementi");
        }

        protected void MenuElementiItemChanged(object sender, ItemPropertyChangedEventArgs e)
        {
            OnPropertyChanged("MenuElementi");
        }

    }
}