using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookMyShow.API.Models;
using DataLayer;

namespace BookMyShow.API.Controllers
{
    public class user_np
    {
        public string user_name { get; set; }
        public string pass { get; set; }
    }

    public class temp
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
    }
    

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
        [HttpPost]
        [Route("UserAuthentication")]
        public IQueryable<int> UserAuthentication( user_np obj)
        {
            MoviesDAL dal_obj = new MoviesDAL();
            string username=obj.user_name;
            string pass=obj.pass;


            var info = (dal_obj.user_authentication(username,pass));
            return info;
        }
        [HttpPost]
        [Route("UserRegistration")]
        public int UserRegistration(temp obj)
        {
            MoviesDAL dal_obj = new MoviesDAL();
            dal_obj.UserRegistration(obj.UserName,obj.Password,obj.MobileNo,obj.Address,obj.EmailId);
            return 1;
        }
    }
}
