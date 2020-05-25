using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;


namespace BookMyShowAppp.Controllers
{
    public class HomeController : Controller
    {
        /*
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }*/

        [HttpGet]
        public void Index()
        {
            MoviesDAL dal_obj = new MoviesDAL();
            var info = (dal_obj.Movies());
            //return (dal_obj.Movies());
            var t = 1;
        }
    }
}
