using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.RequestObjects
{
    public class AddMovieRequest
    {
        public string MovieName { get; set; }
        public int? MovieRating { get; set; }
    }
}
