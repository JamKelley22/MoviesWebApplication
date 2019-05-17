using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.ResponseObjects
{
    public class MovieListItem
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieRating { get; set; }
    }
}
