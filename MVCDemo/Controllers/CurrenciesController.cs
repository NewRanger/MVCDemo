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
                CurrencyContext context = new CurrencyContext();
                currency = context.Currency.Single(cur => cur.id == id);
            }

            return View(currency);
        }

        // GET: Currencies / Edit Course
        // prop: id (currency id)
        public ActionResult Course(int id)
        {
            if(id == 0)
            {
                return View();
            }

            Courses course = new Courses
            {
                currency_id = id,
                buy = 1,
                sell = 1
            };

            CurrencyContext context = new CurrencyContext();
            Courses courseData = context.Courses.FirstOrDefault(cur => cur.currency_id == id);

            if (courseData != null) course = courseData;

            return View(course);
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

        // POST: Currencies / EditCourse
        // prop: id (currency id)
        [HttpPost]
        public ActionResult EditCourse(int? id, double buy, double sell)
        {
            CurrencyContext context = new CurrencyContext();
            Courses course = context.Courses.FirstOrDefault(cor => cor.currency_id == id);

            if (course != null)
            {
                course.buy = buy;
                course.sell = sell;

                context.SaveChanges();
            }
            else
            {
                course = new Courses
                {
                    currency_id = (int)id,
                    buy = buy,
                    sell = sell,
                };

                context.Courses.Add(course);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}