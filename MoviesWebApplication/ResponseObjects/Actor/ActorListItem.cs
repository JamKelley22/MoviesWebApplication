using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.ResponseObjects
{
    public class ActorListItem
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public DateTime ActorDOB { get; set; }
        public DateTime ActorDOD { get; set; }
    }
}
