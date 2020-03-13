using SDR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using SDR.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDR.ViewModels
{
    public class UtenteViewModel : INotifyPropertyChanged
    {
        private const string Url = "";
        private readonly HttpClient _client = new HttpClient();

        private ObservableCollection<Utente> _utenti;

        public ObservableCollection<Utente> Utenti
        {
            get { return _utenti; }
            set
            {
                _utenti = value;
                OnPropertyChanged("Utenti");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged ; 

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public UtenteViewModel()
        {
        }

        protected void UtentiChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Utenti");
        }

        public async Task GetUtentiAsync()
        {

            try
            {
                
              
                List<Utente> lsUtenti = new List<Utente>();
                lsUtenti.Add(new Utente
                {
                    CodiceOperatore = "TEST",
                    CodiceUtente = "Test",
                    NomeUtente  = "TEST"
                });

                Utenti = new ObservableCollection<Utente>(lsUtenti);
                Utenti.CollectionChanged += UtentiChanged;

            }
            catch (Exception ex)
            {
                var errore = ex.StackTrace.ToString();
                
            }
        }

    }
}