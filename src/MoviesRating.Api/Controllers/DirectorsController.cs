using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.Services;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorsController:ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAll()
        {
            var result = await _directorService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DirectorDto>> Get(Guid id)
        {
            var result = await _directorService.GetAsync(id);
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateDirectorDto createDirectorDto)
        {
            var id = await _directorService.CreateAsync(createDirectorDto);
            
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateDirectorDto updateDirectorDto)
        {
            updateDirectorDto.DirectorId = id;
            await _directorService.UpdateAsync(updateDirectorDto);
           
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteDirectorDto = new DeleteDirectorDto { DirectorId = id };
            await _directorService.DeleteAsync(deleteDirectorDto);
           
            return NoContent();
        }
    }
}
