using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DTO;
using BusinessLayer.AutoMapper;

namespace BusinessLayer
{
   public class MoviesBAL
    {
        MoviesDAL obj = new MoviesDAL();
        public List<ThShowDTO> TheatreShowData(int movieid)
        {
            EntityToDTOTheatreShow dto = new EntityToDTOTheatreShow();
            return dto.ConvertTheatreShowVal(obj.TheatreShowValue(movieid));
        }
        public List<SeatNoDTO> GetSeatNo(int theatreid)
        {
            EntityToDTOTheatreShow dto = new EntityToDTOTheatreShow();
            return dto.ConvertSeatNo(obj.GetSeatNo(theatreid));
        }
        public List<MovieTableDTO> Movies()
        {
            EntityToDTOTheatreShow dto = new EntityToDTOTheatreShow();
            return dto.ConvertMovies(obj.Movies());
        }
        public IQueryable<int> userAuthentication(UserDTO val)
        {
            DTOtoEntity entity = new DTOtoEntity();
           return (obj.userAuthentication(entity.ConvertUserDTOtoEntity(val)));
        }
        public void userRegistration(UserDTO val)
        {
            DTOtoEntity entity = new DTOtoEntity();
            obj.UserRegistration(entity.ConvertUserDTOtoEntity(val));
        }
        public void RegisterSeatInfo(BookSeatDTO data)
         {
            DTOtoEntity entity = new DTOtoEntity();
            obj.RegisterSeatInfo(entity.ConvertBookSeat(data));
         }

    }
}
