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
            return   dto.ConvertList(obj.Check(movieid));
        }
      /*  public List<SeatNoDTO> GetSeatNo()
        {
            EntityToDTOTheatreShow dto = new EntityToDTOTheatreShow();
            return dto.ConvertSeatNo(obj.GetSeatNo());
        }*/

    }
}
