using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Data;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DatabaseContext movieContext;
        public MovieController(DatabaseContext databaseContext)
        {
            movieContext = databaseContext;
        }

        [HttpGet]
        [Route("api/getmovies")]
        public List<MovieData> Get()
        {
                var moviesdata = new List<MovieData>();
                var movies = movieContext.Movies;
                var producers = movieContext.Producers;
                var actors = movieContext.Actors;
                var masters = movieContext.MasterMovies;
                foreach (var movie in movies)
                {
                    var moviedata = new MovieData();
                    var listactor = new List<MasterActor>();
                    var MasterMapProducerId = movieContext.MasterMovies.First(x => x.MovieId == movie.MovieId).MasterProducer.ProducerId;
                    moviedata.Movie = movie;
                    var producer = movieContext.Producers.First(x => x.ProducerId == MasterMapProducerId);
                    moviedata.Producer = producer;
                    var actorsIds = from u in masters where u.MovieId == movie.MovieId select u;
                    var actorsId = actorsIds.Select(x => x.ActorId).ToList();
                    foreach (var a in actorsId)
                    {
                        var actor = movieContext.Actors.First(x => x.ActorId == a);
                        listactor.Add(actor);
                    }
                    moviedata.Actors.Concat(listactor);
                    moviesdata.Add(moviedata);
                }
                return moviesdata;
        }

        [HttpPost]
        [Route("api/createmovie")]
        public async Task<bool> CreateMovie([FromBody] MasterMovie movie,int producerId, List<int> actorId)
        {
            try
            {
                movieContext.Movies.Add(movie);
                movieContext.SaveChanges();
                var movieId = movieContext.Movies.First(x => x.MovieName == movie.MovieName).MovieId;
                var mastermapMovieList = new List<MasterMapMovie>();
                foreach (var a in actorId)
                {
                    var mastermapMovie = new MasterMapMovie();
                    mastermapMovie.MovieId = movieId;
                    mastermapMovie.ActorId = a;
                    mastermapMovie.ProducerId = producerId;
                    mastermapMovieList.Add(mastermapMovie);
                }
                movieContext.MasterMovies.AddRange(mastermapMovieList);
                await movieContext.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }

        [HttpPost]
        [Route("api/updatemovie")]
        public void Post([FromBody] MasterMovie movie, int producerId, List<int> actorId)
        {
            var moviee = movieContext.Movies.Where(x => x.MovieId == movie.MovieId).FirstOrDefault();
            moviee.MovieName = movie.MovieName;
            moviee.DateOfRelease = movie.DateOfRelease;
            var masterdatamovie = movieContext.MasterMovies.Where(x => x.MovieId == movie.MovieId);
            movieContext.MasterMovies.RemoveRange(masterdatamovie);
            var mastermapMovieList = new List<MasterMapMovie>();
            foreach (var a in actorId)
            {
                var mastermapMovie = new MasterMapMovie();
                mastermapMovie.MovieId = movie.MovieId;
                mastermapMovie.ActorId = a;
                mastermapMovie.ProducerId = producerId;
                mastermapMovieList.Add(mastermapMovie);
            }
            movieContext.MasterMovies.AddRange(mastermapMovieList);
        }

    }
}
