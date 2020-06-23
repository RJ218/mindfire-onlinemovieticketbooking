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
using BookMyShowAppp.Filters;
using System.Web.Http.Results;
using BookMyShowAppp.Filter;

namespace BookMyShowAppp.Controllers
{
    


    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
       [HttpGet]
       [Route("GetData")]
       [CustomAuthentication]
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
        [CustomAuthentication]
        //returns movie table entries to movie page
        public IHttpActionResult GetInfo()
        {
            // MoviesDAL cls = new MoviesDAL();
            //var info = (cls.Movies());
            MoviesDAL movbal = new MoviesDAL();
            return Ok(movbal.Movies());
        }

        [HttpGet]
        [Route("GetTheatreId")]
        [CustomAuthentication]
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
        
        public HttpResponseMessage UserAuthentication(UserDTO obj)
        {
           
           string token =  TokenManager.GenerateToken(obj.UserName);
            MoviesBAL bal_obj = new MoviesBAL();
             int userid= (bal_obj.userAuthentication(obj));
            return Request.CreateResponse(HttpStatusCode.OK ,value:token +":"+userid);
        }
        [HttpPost]
        [Route("UserRegistration")]
        
        public int UserRegistration(UserDTO obj)
        {
            MoviesBAL Bal_obj = new MoviesBAL();
            Bal_obj.userRegistration(obj);
            return 1;
        }

        [HttpGet]
        [Route("GetBookingInfo")]
        [CustomAuthentication]
        public List<Booking> GetBookingInfo(int showid)
        {
            MoviesDAL bal_obj = new MoviesDAL();
            return bal_obj.GetBookingInfo(showid);

        }
        [HttpGet]
        [Route("GetCastInfo")]
        [CustomAuthentication]
        public List<Cast> GetCastInfo()
        {
            MoviesDAL dal_obj = new MoviesDAL();
            return dal_obj.GetCastInfo();
        }
    }
}
