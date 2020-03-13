using SDR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using SDR.Helpers;
using System.Threading.Tasks;
using System.Text;
using Plugin.Connectivity;

namespace SDR
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public BaseViewModel()
        {

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


        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public bool IsConnectionOk
        {
            get {
                if (CrossConnectivity.Current.IsConnected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

}

