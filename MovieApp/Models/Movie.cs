using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
