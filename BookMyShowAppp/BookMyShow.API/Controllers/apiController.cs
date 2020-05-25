using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DataLayer;

namespace BookMyShow.API.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class apiController : ApiController
    {
        [HttpGet]
        [Route("GetInfo")]
        public IEnumerable<DataLayer.MovieTable> GetInfo()
        {
            
                MoviesDAL dal_obj = new MoviesDAL();
                var info = (dal_obj.Movies());
                return (dal_obj.Movies());
               
            
        }
    }
}
