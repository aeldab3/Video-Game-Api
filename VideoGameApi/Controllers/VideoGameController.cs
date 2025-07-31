using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly VideoGameDbContext _context;
        public VideoGameController(VideoGameDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame is null)
                return NotFound();

            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> CreateVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest("Video game cannot be null.");

            await _context.VideoGames.AddAsync(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
        {
            if (updatedGame is null)
                return BadRequest("Video game cannot be null.");

            var existingGame = await _context.VideoGames.FindAsync(id);
            if (existingGame is null)
                return NotFound();

            existingGame.Title = updatedGame.Title;
            existingGame.Platform = updatedGame.Platform;
            existingGame.Developer = updatedGame.Developer;
            existingGame.Publisher = updatedGame.Publisher;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideoGame(int id)
        {
            var existingGame = _context.VideoGames.FirstOrDefault(vg => vg.Id == id);
            if (existingGame is null)
                return NotFound();

            _context.VideoGames.Remove(existingGame);
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
