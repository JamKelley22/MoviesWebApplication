using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApplication.ResponseObjects
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(100)]
        public string MovieName { get; set; }
        [Required]
        public int MovieRating { get; set; }
    }
}
