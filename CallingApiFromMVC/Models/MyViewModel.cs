using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallingApiFromMVC.Models
{
    public class MyViewModel
    {
        public string curr_id { get; set; }
        public List<Currency> Currencys { get; set; }
        public List<UOM> UOMs { get; set; }
    }
}
