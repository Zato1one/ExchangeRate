using ExchangeRate.BLL.Services.Models;
using ExchangeRate.BLL.Services.Services.Contracts;
using ExchangeRate.BLL.Services.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRate.BLL.Services.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private static IReadOnlyList<Valute> CurrencyCodes { get; }
        static ExchangeRateService()
        {
            CurrencyCodes = InitializeCurrencyCodes();
        }

        private static IReadOnlyList<Valute> InitializeCurrencyCodes()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var xmlFileName = "Resources\\XML_val.xml";

            var pathXmlFile = $"{baseDirectory}{xmlFileName}";

            return XmlParser<XmlCurrencyCodes>.DeserializeXMLFile(pathXmlFile).CurrencyCodes;
        }

        public IReadOnlyList<Valute> GetCurrencyCodes()
        {
            return CurrencyCodes;
        }

        public async Task<IReadOnlyList<Record>> GetCurrencyStatsByCode(string currencyCode, DateTime startDate, DateTime endDate)
        {
            var url = $"http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1={startDate.ToString("dd/MM/yyyy")}&date_req2={endDate.ToString("dd/MM/yyyy")}&VAL_NM_RQ={currencyCode}";

            var response = await HttpSender.SendUrl(url);
            return XmlParser<ValCurs>.DeserializeXMLString(response).Records;
        }
    }
}
