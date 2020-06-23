using AutoMapper;
using DataLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
  public  class EntityToDTOTheatreShow
    {

        public List<ThShowDTO> ConvertTheatreShowVal(List<TheatreShow> id)
        {
            List<ThShowDTO> map = new List<ThShowDTO>();
            Mapper.Initialize(config =>
            {
                config.CreateMap<TheatreShow,ThShowDTO>();
            });
            for (int i = 0; i < id.Count; i++)
                map.Add(Mapper.Map<ThShowDTO>(id[i]));

            return map;
        }
        public List<SeatNoDTO> ConvertSeatNo(List<Seat> id)
        {
            List<SeatNoDTO> map = new List<SeatNoDTO>();
            Mapper.Initialize(config =>
            {
                config.CreateMap<Seat, SeatNoDTO>();
            });
            for (int i = 0; i < id.Count; i++)
                map.Add(Mapper.Map<SeatNoDTO>(id[i]));

            return map;
        }
        //mapper to convert movietable of entity to movietable of dto
        public List<MovieTableDTO> ConvertMovies(List<MovieTable> id)
        {
            List<MovieTableDTO> map = new List<MovieTableDTO>();
            Mapper.Initialize(config =>
            {
                config.CreateMap<MovieTable, MovieTableDTO>();
            });
            for (int i = 0; i < id.Count; i++)
                map.Add(Mapper.Map<MovieTableDTO>(id[i]));

            return map;
        }
        

    }
}
