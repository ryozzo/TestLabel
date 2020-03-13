using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace SDR.Models
{
    [Preserve(AllMembers = true)]
    public class VoceMenu : System.ComponentModel.INotifyPropertyChanged
    {

        public string Codice { get; set; }
        public string Descrizione { get; set; }
        private int _numeroNotifica { get; set; }
        public int NumeroNotifica
        {
            get { return _numeroNotifica; }
            set
            {
                _numeroNotifica = value;
                OnPropertyChanged("NumeroNotifica");
            }
        }
        public bool NotificaVisibile
        {
            get { return NumeroNotifica > 0 ; }
        }

        public VoceMenu(string c,string d, int n)
        {
            Codice = c;
            Descrizione = d;
            NumeroNotifica = n;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }




}
