using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApplication.Data;
using MoviesWebApplication.RequestObjects;
using MoviesWebApplication.ResponseObjects;

namespace MoviesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private Context _ctx;
        public MoviesController(Context context)
        {
            _ctx = context;
        }

        [HttpGet] 
        public MoviesListResponse GetMovies()
        {
            var resp = new MoviesListResponse();
            var movies = _ctx.Movies;
            resp.TotalResults = movies.Count();
            resp.Movies = movies.Select(x => new MovieListItem()
            {
                MovieId = x.MovieId,
                MovieName = x.MovieName,
                MovieRating = x.MovieRating
            }).ToList();

            return resp;
        }

        [HttpGet("{id}")]
        public MovieListItem GetMovie(int id)
        {
            var movies = _ctx.Movies;
            var matchingMovie = movies.Find(id);
            if(matchingMovie == null)
            {
                Response.StatusCode = 404;
                var jsonString = "{\"Error\":\"No Matching Movie with MovieId\"}";
                byte[] data = Encoding.UTF8.GetBytes(jsonString);
                Response.ContentType = "application/json";
                Response.Body.Write(data, 0, data.Length);
            }
            var matchingMovieListItem = new MovieListItem()
            {
                MovieId = matchingMovie.MovieId,
                MovieName = matchingMovie.MovieName,
                MovieRating = matchingMovie.MovieRating
            };
            return matchingMovieListItem;
        }

        [HttpPost]
        public MovieListItem AddMovie(AddMovieRequest movieRequest)
        {
            var movie = new Movie()
            {
                MovieName = movieRequest.MovieName,
                MovieRating = movieRequest.MovieRating.Value
            };
            _ctx.Movies.Add(movie);
            _ctx.SaveChanges();

            var matchingMovie = _ctx.Movies.Find(movie.MovieId);

            var matchingMovieListItem = new MovieListItem()
            {
                MovieId = matchingMovie.MovieId,
                MovieName = matchingMovie.MovieName,
                MovieRating = matchingMovie.MovieRating
            };
            return matchingMovieListItem;
        }

        [HttpPut("{id}")]
        public MovieListItem UpdateMovie(int id, [FromBody] UpdateMovieRequest movieRequest)
        {
            var movies = _ctx.Movies;
            var matchingMovie = movies.Find(id);
            if (matchingMovie == null)
            {
                Response.StatusCode = 404;
                var jsonString = "{\"Error\":\"No Matching Movie with MovieId\"}";
                byte[] data = Encoding.UTF8.GetBytes(jsonString);
                Response.ContentType = "application/json";
                Response.Body.Write(data, 0, data.Length);
            }

            matchingMovie.MovieName = movieRequest.MovieName ?? matchingMovie.MovieName;
            matchingMovie.MovieRating = movieRequest.MovieRating ?? matchingMovie.MovieRating;

            _ctx.Movies.Update(matchingMovie);
            _ctx.SaveChanges();

            var matchingMovieListItem = new MovieListItem()
            {
                MovieId = matchingMovie.MovieId,
                MovieName = matchingMovie.MovieName,
                MovieRating = matchingMovie.MovieRating
            };
            return matchingMovieListItem;
        }

        [HttpDelete("{id}")]
        public MovieListItem DeleteMovie(int id)
        {
            var movies = _ctx.Movies;
            var matchingMovie = movies.Find(id);
            if (matchingMovie == null)
            {
                Response.StatusCode = 404;
                var jsonString = "{\"Error\":\"No Matching Movie with MovieId\"}";
                byte[] data = Encoding.UTF8.GetBytes(jsonString);
                Response.ContentType = "application/json";
                Response.Body.Write(data, 0, data.Length);
            }

            _ctx.Movies.Remove(matchingMovie);
            _ctx.SaveChanges();

            var matchingMovieListItem = new MovieListItem()
            {
                MovieId = matchingMovie.MovieId,
                MovieName = matchingMovie.MovieName,
                MovieRating = matchingMovie.MovieRating
            };
            return matchingMovieListItem;
        }
    }
}