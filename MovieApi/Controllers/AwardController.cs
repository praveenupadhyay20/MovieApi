using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos;
using MovieApi.Entity;
using MovieApi.Repositories;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AwardController : ControllerBase
    {
        private readonly ILogger<AwardController> _logger;
        private readonly IAwardRepository _awardRepository;
        private readonly IMapper _mapper;


        public AwardController(IAwardRepository awardRepository, ILogger<AwardController> logger, IMapper mapper)
        {
            _awardRepository = awardRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAwards()
        {
            var awards = await _awardRepository.GetAllAwards();
            return Ok(awards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAwardById(int id)
        {
            var award = await _awardRepository.GetAwardById(id);
            if (award == null)
            {
                return NotFound();
            }
            return Ok(award);
        }

        [HttpPost]
        public async Task<IActionResult> AddAward(AddAwardDto awardDto)
        {
            var award = _mapper.Map<Award>(awardDto);
            await _awardRepository.AddAward(award);
            return CreatedAtAction(nameof(GetAwardById), new { id = award.Id }, award);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAward(UpdateAwardDto awardDto)
        {
            var award = _mapper.Map<Award>(awardDto);
            await _awardRepository.UpdateAward(award);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAward(int id)
        {
            await _awardRepository.DeleteAward(id);
            return NoContent();
        }
    }
}
