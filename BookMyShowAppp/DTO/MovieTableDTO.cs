using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class MovieTableDTO
    {
        public int MovieId { get; set; }
        public string Category { get; set; }
        public string Trailer { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public string ImageAddress { get; set; }
        public string Synopsis { get; set; }
    }
}
