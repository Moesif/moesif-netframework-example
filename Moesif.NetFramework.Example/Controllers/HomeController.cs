using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moesif.NetFramework.Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Console.Out.WriteLine("Home Index");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Console.Out.WriteLine("Home about");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}