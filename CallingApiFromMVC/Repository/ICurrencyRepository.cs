using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallingApiFromMVC.Models;

namespace CallingApiFromMVC.Repository
{
   public interface ICurrencyRepository
    {
        Task<List<Currency>> GetCurrencys();
    }
}
