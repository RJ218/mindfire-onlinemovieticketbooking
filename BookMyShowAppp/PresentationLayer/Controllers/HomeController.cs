using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DTO;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;
using System.Net.Http.Headers;
using paytm;
using System.Net.Mail;
using System.Net;

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

        [HttpPost]
        public ActionResult UserRegistration(UserDTO user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60562/api/");
                var postTask = client.PostAsJsonAsync<UserDTO>("UserRegistration", user);
                postTask.Wait();
                var result = postTask.Result;
                // var result = client.PostAsJsonAsync("http://localhost:60562/api/UserRegistration", user).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                    ViewBag.data = "successfully registered!!";
                }
                return View();
            }
          }
        public void Payment(int userid,string emailid,long mob,int price)
        {
            var rnd = new Random();
            String merchantKey = "E9urF%3G!7KZa1Ql";
            var paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", "QbXnya22481936477274");
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEBSTAGING");
            parameters.Add("EMAIL",emailid);
            parameters.Add("MOBILE_NO", mob.ToString());
            parameters.Add("CUST_ID", userid.ToString());
            parameters.Add("ORDER_ID", rnd.Next(2, 999999).ToString());
            parameters.Add("TXN_AMOUNT",price.ToString());
            parameters.Add("CALLBACK_URL", "http://localhost:60564/Home/SendEmail?receiver="+emailid+"&price="+price); //This parameter is not mandatory. Use this to pass the callback url dynamically.

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

        public void SendEmail(string receiver,int price)
        {

            MailMessage mm = new MailMessage("shadowfrdmlb@gmail.com", receiver);
            mm.Subject = "Order Confirmation mail";
            mm.Body = "Your tickets are booked and the total price is Rs "+price ;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("shadowfrdmlb@gmail.com", "Pointbreak");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

           // SendSms(Amount);
           // return RedirectToAction("SuccessPage", "Dominos");
        }
        /* public void SendEmail(string receiver)
        {
        
                    var senderEmail = new MailAddress("shadowfrdmlb@gmail.com", "Himanshu");
                    var receiverEmail = new MailAddress(receiver, "Nupur");
                    var password = "Pointbreak";
                    var sub = "";
                    var body = "The total amount debited from your account is ";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        //DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = true,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                       Subject = sub,
                       Body = body
                     })
                    {
                       mess.IsBodyHtml = false;
                        smtp.Send(mess);
                    }
    }*/
    }
}
