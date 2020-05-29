using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
using BusinessLayer;
using System.Web.Http.Cors;

namespace BookMyShowAppp.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
        [HttpGet]
       [Route("GetData")]
        public IHttpActionResult GetData(int movieid)
        {
            //  MoviesDAL cls = new MoviesDAL();
            //return Ok(cls.Check(movieid));
            MoviesBAL cl = new MoviesBAL();
            return Ok(cl.TheatreShowData(movieid));
        }

        [HttpGet]
        [Route("GetInfo")]
        public IHttpActionResult GetInfo()
        {
            MoviesDAL cls = new MoviesDAL();
            var info = (cls.Movies());
            return Ok(cls.Movies());
        }

        [HttpGet]
        [Route("GetTheatreId")]
        public IHttpActionResult GetTheatreId(int data)
        {
            MoviesDAL check = new MoviesDAL();
           return Ok(check.GetSeatNo(data));
            
        }
       [HttpPost]
        [Route("SubmitSeats")]
        public IHttpActionResult SubmitSeats([FromBody] BookSeat data)
        {
            MoviesDAL check = new MoviesDAL();
            check.RegisterSeatInfo(data);
            return Ok("gg");

        }
    }
}
