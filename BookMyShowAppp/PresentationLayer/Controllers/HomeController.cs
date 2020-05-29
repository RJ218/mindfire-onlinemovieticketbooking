using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MoviePage()
        {
            return View();
        }
        public ActionResult MovieInformation(int Movieid)
        {
            ViewData["movieid"] = Movieid;
            return View();
        }
       /* public ActionResult Martian()
        { return View();
        }*/
        public ActionResult BookNow()//common page
        {
            
            return View();
        }
        public ActionResult BookSeats()
        { return View(); }
    }
}