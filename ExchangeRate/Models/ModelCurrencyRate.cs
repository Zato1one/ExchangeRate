using ExchangeRate.BLL.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExchangeRate.Models
{
    public class ModelCurrencyRate
    {
        public IReadOnlyList<Valute> CurrencyCodes { get; set; }
        public IReadOnlyCollection<Record> Records { get; set; }
    }
}