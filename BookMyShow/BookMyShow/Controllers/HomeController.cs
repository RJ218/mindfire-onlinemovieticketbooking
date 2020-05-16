using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary1;
namespace BookMyShow.Controllers
{
    public class HomeController : ApiController
    {

        public List<Theatre> Get()
        {
            Class1 cls = new Class1();
             return cls.Display();
        }
        
    }
}
