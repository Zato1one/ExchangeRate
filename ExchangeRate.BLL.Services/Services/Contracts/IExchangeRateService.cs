using ExchangeRate.BLL.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.BLL.Services.Services.Contracts
{
    public interface IExchangeRateService
    {
        IReadOnlyList<Valute> GetCurrencyCodes();
        Task<IReadOnlyList<Record>> GetCurrencyStatsByCode(string currencyCode, DateTime startDate, DateTime endDate);
    }
}
