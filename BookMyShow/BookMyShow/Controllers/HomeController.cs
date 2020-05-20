using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary1;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
     [HttpGet]
     public IHttpActionResult GetData(int movieid)
        {
          
           //int m= HttpRequest.QueryString["movieid"].ToString();
            Class1 cls = new Class1();
            return Ok(cls.Check(movieid));
        }  
    }
}
