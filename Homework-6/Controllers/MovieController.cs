using Imdb_Clone.Application.MovieOperations.Commands;
using Imdb_Clone.Application.MovieOperations.Queries;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using Microsoft.AspNetCore.Mvc;
using static Imdb_Clone.Application.MovieOperations.Commands.UpdateMovieCommand;

namespace Imdb_Clone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ImdbDbContext _dbContext;

        public MovieController(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new(_dbContext);
            var movies = query.Handle();

            return Ok(movies);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            CreateMovieCommand command = new(_dbContext);
            command.Handle(movie);

            return Ok("Register successfull");
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieVM updatedMovie)
        {
            UpdateMovieCommand command = new(_dbContext);
            command.MovieId = id;
            command.Model = updatedMovie;
            command.Handle();

            return Ok("Update successfull");
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new(_dbContext);
            command.MovieId = id;
            command.Handle();

            return Ok("Delete successfull");
        }

    }
}
