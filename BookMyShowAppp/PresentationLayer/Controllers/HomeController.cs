using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using paytm;


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
       
        public ActionResult BookNow()//common page
        {
            
            return View();
        }
        public ActionResult BookSeats()
        {
            return View();
        }
        public ActionResult UserRegistration()
        {
            return View();
        }

        public void Paytm_Gateway()
        {
            var rnd = new Random();
            String merchantKey = "f#a2z34f%eytI8TV";
            var paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", "NwAsdx99491884368365");
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEBSTAGING");
            parameters.Add("EMAIL", "rachitjain218@gmail.com");
            parameters.Add("MOBILE_NO", "8588014264");
            parameters.Add("CUST_ID", "rnd");
            parameters.Add("ORDER_ID", rnd.Next(2,999999).ToString());
            parameters.Add("TXN_AMOUNT", rnd.Next(99, 9999).ToString());
           // parameters.Add("CALLBACK_URL", "url"); //This parameter is not mandatory. Use this to pass the callback url dynamically.

            string checksum = CheckSum.generateCheckSum(merchantKey, parameters);

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);
        }

        public ActionResult sucessfull_payment()
        {
            return View();
        }
    }
}