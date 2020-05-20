using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
namespace BookMyShowAppp.Controllers
{
    public class DefaultController : ApiController
    {
        public List<MovieTable> Get()
        {
            MoviesDAL cls = new MoviesDAL();
            return cls.Display();
        }
    }
}
