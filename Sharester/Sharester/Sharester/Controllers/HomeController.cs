using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharester.Models;
using Sharester.Services;

namespace Sharester.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }

        public ActionResult Sell()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult Suggestions()
        {
            return View();
        }

        public ActionResult RealEstate()
        {
            return View();
        }

        public ActionResult DomesticHelp()
        {
            return View();
        }

        public ActionResult Others()
        {
            return View();
        }

        public ActionResult Policy()
        {
            return View();
        }

        public ActionResult Item(Guid itemId)
        {
            Item item = ItemService.GetItem(itemId);
            //UserModel user = ItemService
            ViewBag.item = item;
            return View(item);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
