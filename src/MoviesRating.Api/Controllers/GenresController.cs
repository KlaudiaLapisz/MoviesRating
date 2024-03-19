using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.DTO.Genres;
using MoviesRating.Application.Services;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController:ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAll()
        {
            var result = await _genreService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GenreDto>> Get(Guid id)
        {
            var result= await _genreService.GetAsync(id);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post (CreateGenreDto createGenredto)
        {
            var id = await _genreService.CreateAsync(createGenredto);
            
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateGenreDto updateGenredto)
        {
            updateGenredto.GenreId = id;
            await _genreService.UpdateAsync(updateGenredto);
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteGenreDto = new DeleteGenreDto { GenreId = id };
            await _genreService.DeleteAsync(deleteGenreDto);
            
            return NoContent();
        }
    }
}
