using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace SDR.Models
{
   
    [Preserve(AllMembers = true)]
    public class EnvelopResponse
    {
        public string success { get; set; }
        public string error { get; set; }
        public Object data { get; set; }

        [JsonConstructor]
        public EnvelopResponse() 
        {

        }
    
    }

    
}
