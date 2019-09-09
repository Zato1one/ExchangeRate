using AutoMapper;
using ExchangeRate.BLL.Services.Services.Contracts;
using ExchangeRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExchangeRate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExchangeRateService ExchangeRateService;
        public HomeController(IExchangeRateService ExchangeRateService)
        {
            this.ExchangeRateService = ExchangeRateService;
        }

        public async Task<ActionResult> Index()
        {
            var dateTimeNow = DateTime.UtcNow;
            var currencyCodes = ExchangeRateService.GetCurrencyCodes();
            var records = await ExchangeRateService.GetCurrencyStatsByCode(currencyCodes[0].Code, new DateTime(dateTimeNow.Year, 1, 1), dateTimeNow);
            var model = new ModelCurrencyRate()
            {
                CurrencyCodes = currencyCodes,
                Records = records
            };
            return View(model);
        }

        public async Task<JsonResult> Records(string code)
        {
            var dateTimeNow = DateTime.UtcNow;
            return Json(await ExchangeRateService.GetCurrencyStatsByCode(code, new DateTime(dateTimeNow.Year, 1, 1), dateTimeNow), JsonRequestBehavior.AllowGet);
        }
    }
}