using DataLayer;
using paytm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class PaytmController : Controller
    {
        // GET: Paytm
        public ActionResult Index()
       {
           // Random num = new Random();
            string merchantKey = "E9urF%3G!7KZa1Ql";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", "QbXnya22481936477274");
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEBSTAGING");
            parameters.Add("EMAIL","gfhgc");
            parameters.Add("MOBILE_NO", "tyd");//user.MobileNo.ToString());
            parameters.Add("CUST_ID", "657");//userid.ToString());
            parameters.Add("ORDER_ID", "ord_");
            parameters.Add("TXN_AMOUNT","786");
            parameters.Add("CALLBACK_URL", "http://localhost:60564/Home/Index");

            string checksum = paytm.CheckSum.generateCheckSum(merchantKey, parameters);
            string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction";

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

            ViewBag.Data = outputHTML;
            return View();
        }
    }
    }
