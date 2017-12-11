using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Archives()
        {
            ViewBag.Message = "Where all the music is stored.";

            return View();
        }

        public ActionResult Songs()
        {
            ViewBag.Message = "Songs functions";

            return View();
        }

    }
}