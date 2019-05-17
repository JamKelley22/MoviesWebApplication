using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.ResponseObjects
{
    public class ActorsListResponse
    {
        public int TotalResults { get; set; }
        public List<ActorListItem> Actors { get; set; }
    }
}
