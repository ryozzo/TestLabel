using Xamarin.Forms.Internals;

namespace SDR.Models
{
    public class Utente
    {
        public string CodiceUtente { get; set; }
        public string NomeUtente { get; set; }
        public string CodiceOperatore { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class UtenteParams
    {
    }

    [Preserve(AllMembers = true)]
    public class UtenteResult
    {
        public string CodiceUtente { get; set; }
        public string NomeUtente { get; set; }
        public string CodiceOperatore { get; set; } 
    }
}
