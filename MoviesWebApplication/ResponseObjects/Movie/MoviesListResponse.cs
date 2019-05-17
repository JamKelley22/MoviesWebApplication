using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.ResponseObjects
{
    public class MoviesListResponse
    {
        public int TotalResults { get; set; }
        public List<MovieListItem> Movies { get; set; }
    }
}
