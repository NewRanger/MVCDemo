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
        // GET: Currencies / Index
        public ActionResult Index()
        {
            CurrencyContext context = new CurrencyContext();

            var viewModel = new CurrenciesViewModel
            {
                Currencies = context.Currency.ToList()
            };

            return View(viewModel);
        }

        // GET: Currencies / Edit
        public ActionResult Edit(int? id)
        {
            Currency currency = new Currency
            {
                code = "",
                name = "",
                name_lat = "",
                order_index = 1,
            };

            if (id != null)
            {
                CurrencyContext currencyContext = new CurrencyContext();
                currency = currencyContext.Currency.Single(cur => cur.id == id);
            }

            return View(currency);
        }

        // POST: Currencies / EditCurrency
        [HttpPost]
        public ActionResult EditCurrency(int? id, string code, string name, string name_lat, int order_index)
        {
            CurrencyContext context = new CurrencyContext();

            if (id != null && id > 0)
            {
                Currency currency = context.Currency.Single(cur => cur.id == id);

                currency.code = code;
                currency.name = name;
                currency.name_lat = name_lat;
                currency.order_index = order_index;

                context.SaveChanges();
            } else
            {
                Currency currency = new Currency
                {
                    code = code,
                    name = name,
                    name_lat = name_lat,
                    order_index = order_index,
                };

                context.Currency.Add(currency);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}