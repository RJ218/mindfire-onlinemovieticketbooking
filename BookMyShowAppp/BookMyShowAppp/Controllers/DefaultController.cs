using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
using DTO;
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
       //returns thatre and show table values 
       public IHttpActionResult GetData(int movieid)
        {
            //  MoviesDAL cls = new MoviesDAL();
            //return Ok(cls.Check(movieid));
            MoviesBAL movbal = new MoviesBAL();
            return Ok(movbal.TheatreShowData(movieid));
        }
        [HttpGet]
        [Route("GetInfo")]
        //returns movie table entries to movie page
        public IHttpActionResult GetInfo()
        {
            // MoviesDAL cls = new MoviesDAL();
            //var info = (cls.Movies());
            MoviesBAL movbal = new MoviesBAL();
            return Ok(movbal.Movies());
        }

        [HttpGet]
        [Route("GetTheatreId")]
        public IHttpActionResult GetTheatreId(int theatreid)
        {
            // MoviesDAL check = new MoviesDAL();
            MoviesBAL movbal = new MoviesBAL();
           return Ok(movbal.GetSeatNo(theatreid));
            
        }
        [HttpPost]
        [Route("SubmitSeats")]
        public IHttpActionResult SubmitSeats([FromBody] BookSeatDTO data)
        {
            //MoviesDAL check = new MoviesDAL();
            MoviesBAL movbal = new MoviesBAL();
            movbal.RegisterSeatInfo(data);
            return Ok("gg");

        }
        [HttpPost]
        [Route("UserAuthentication")]
        public IQueryable<int> UserAuthentication(UserDTO obj)
        {
            MoviesBAL bal_obj = new MoviesBAL();
             return (bal_obj.userAuthentication(obj));
        }
        [HttpPost]
        [Route("UserRegistration")]
        public int UserRegistration(UserDTO obj)
        {
            MoviesBAL Bal_obj = new MoviesBAL();
            Bal_obj.userRegistration(obj);
            return 1;
        }
    }
}
