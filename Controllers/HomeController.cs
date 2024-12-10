using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialCelesteCrud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            ViewBag.Message = "Your application description page.";

            return RedirectToAction("Index","Clientes");
        }

        public ActionResult Videojuegos()
        {
            ViewBag.Message = "Your contact page.";

            return RedirectToAction("Index","Videojuegos");
        }
    }
}