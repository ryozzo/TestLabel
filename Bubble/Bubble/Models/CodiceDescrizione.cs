using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace SDR.Models
{
    [Preserve(AllMembers = true)]
    public class CodiceDescrizione
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }

        public CodiceDescrizione(string c,string d)
        {
            Codice = c;
            Descrizione = d;
        }
    }


    public class CodiceDescrizioneResult
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }

    }


}
