using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.Data
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ActorName { get; set; }
        [Required]
        public DateTime ActorDOB { get; set; }
        public DateTime ActorDOD { get; set; }
    }
}
