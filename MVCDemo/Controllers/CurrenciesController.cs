using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using MVCDemo.ViewModels;

namespace MVCDemo.Controllers
{
    public class CurrenciesController : Controller
    {
        // GET: Currencies
        public ActionResult Index()
        {
            CurrencyContext currencyContext = new CurrencyContext();

            var viewModel = new CurrenciesViewModel
            {
                Currencies = currencyContext.Currency.ToList()
            };

            return View(viewModel);
        }

        // GET: Currency / Edit
        public ActionResult Edit(int? id)
        {
            Currency currency = new Currency
            {
                code = "",
                name = "",
                name_lat = "",
                order_index = 0,
            };

            if (id != null)
            {
                CurrencyContext currencyContext = new CurrencyContext();
                currency = currencyContext.Currency.Single(cur => cur.id == id);
            }
           

            return View(currency);

        }

        // POST: Currency / EditCurrency
        [HttpPost]
        public ActionResult EditCurrency(int id, string code, string name, string name_lat, int order_index)
        {
            CurrencyContext currencyContext = new CurrencyContext();

            if (id != null && id > 0)
            {
                Currency currency = currencyContext.Currency.Single(cur => cur.id == id);

                currency.code = code;
                currency.name = name;
                currency.name_lat = name_lat;
                currency.order_index = order_index;

                currencyContext.SaveChanges();
            } else
            {
                Currency currency = new Currency
                {
                    code = code,
                    name = name,
                    name_lat = name_lat,
                    order_index = order_index,
                };

                currencyContext.Currency.Add(currency);
                currencyContext.SaveChanges();
            }
            

            return RedirectToAction("Index");

        }
    }
}