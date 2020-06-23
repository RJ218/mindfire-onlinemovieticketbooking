using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DTO;
using AutoMapper;

namespace BusinessLayer.AutoMapper
{
   public class DTOtoEntity
    {
        public User ConvertUserDTOtoEntity(UserDTO user)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<UserDTO,User>();
            });
            var map = Mapper.Map<User>(user);
            return map;

        }
        public BookSeat ConvertBookSeat(BookSeatDTO id)
        {
           // List<BookSeat> map = new List<BookSeat>();
            Mapper.Initialize(config =>
            {
                config.CreateMap<BookSeatDTO, BookSeat>();
                config.CreateMap<Value_dto, Value>();
            });
            

           // for (int i = 0; i < id.SeatF.Count; i++)
              // map.Add(Mapper.Map<BookSeat>(id.SeatF[i]));
            var map = Mapper.Map<BookSeat>(id);
            
            return map;
        }

    }
}
