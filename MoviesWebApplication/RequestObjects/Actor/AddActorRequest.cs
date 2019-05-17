using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.RequestObjects
{
    public class AddActorRequest
    {
        public string ActorName { get; set; }
        public DateTime ActorDOB { get; set; }
        public DateTime ActorDOD { get; set; }
    }
}
