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
using BookMyShowAppp.Filter;

namespace BookMyShowAppp.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
       [HttpGet]
       [Filter.CustomAuthentication]
        [Route("GetData")]
       //returns thatre and show table values 
       public IHttpActionResult GetData(int movieid)
        {
            MoviesBAL movbal = new MoviesBAL();
            return Ok(movbal.TheatreShowData(movieid));
        }
        [HttpGet]
        [Filter.CustomAuthentication]
        [Route("GetInfo")]
        //returns movie table entries to movie page
        public IHttpActionResult GetInfo()
        {
             MoviesDAL movbal = new MoviesDAL();
            return Ok(movbal.Movies());
        }
        [HttpGet]
        [Route("GetCastInfo")]
        public List<Cast> GetCastInfo()
        {
            MoviesDAL dal_obj = new MoviesDAL();
            return dal_obj.GetCastInfo();
        }
        [HttpGet]
        [Filter.CustomAuthentication]
        [Route("GetTheatreId")]
        public IHttpActionResult GetTheatreId(int theatreid)
        {
            MoviesBAL movbal = new MoviesBAL();
           return Ok(movbal.GetSeatNo(theatreid));
            
        }
        [HttpPost]
        [Filter.CustomAuthentication]
        [Route("SubmitSeats")]
        public IHttpActionResult SubmitSeats([FromBody] BookSeatDTO data)
        {
            MoviesBAL movbal = new MoviesBAL();
            
            return Ok(movbal.RegisterSeatInfo(data));
        }
         [HttpPost]
         [Route("UserAuthentication")]
         public HttpResponseMessage UserAuthentication(UserDTO obj)
         {
             MoviesBAL bal_obj = new MoviesBAL();
            var val=bal_obj.userAuthentication(obj);
            
            if(val==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway,message:"username and password invalid");
            }
            else
            {
                var token = TokenManager.GenerateToken(val.UserName);

                return Request.CreateResponse(HttpStatusCode.OK,value:token+":"+val.UserId);
               
            }
         }
        [HttpPost]
        [Route("UserRegistration")]
        public int UserRegistration(UserDTO user)
        {
            MoviesBAL Bal_obj = new MoviesBAL();
            Bal_obj.userRegistration(user);
            return 1;
        }
        [HttpGet]
        [Filter.CustomAuthentication]
        [Route("GetBookingInfo")]
        public List<Booking> GetBookingInfo(int showid)
        {
            MoviesDAL bal_obj = new MoviesDAL();
            return bal_obj.GetBookingInfo(showid);
        }
        [HttpGet]
        public void userddata(int userid)
        {
            MoviesDAL m = new MoviesDAL();
            m.userddata(userid);
        }
    }
}
