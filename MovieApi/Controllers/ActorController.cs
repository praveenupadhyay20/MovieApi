using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Database;
using MovieApi.Dtos;
using MovieApi.Entity;
using MovieApi.Job;
using MovieApi.Repositories;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public ActorController(IMovieRepository movieRepository, ILogger<MovieController> logger, IMapper mapper)
        {
            _logger = logger;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var actor = await _movieRepository.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }
    }
}
