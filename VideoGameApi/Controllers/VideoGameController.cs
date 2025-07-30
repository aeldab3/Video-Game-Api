using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame { Id = 1, Title = "Spider-Man 2", Platform = "PS5", Developer = "Insomniac Games", Publisher = "Sony Interactive Entertainment" },
            new VideoGame { Id = 2, Title = "God of War", Platform = "PS4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
            new VideoGame { Id = 3, Title = "Minecraft", Platform = "Multi-platform", Developer = "Mojang Studios", Publisher = "Mojang Studios" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var videoGame = videoGames.FirstOrDefault(vg => vg.Id == id);
            if (videoGame is null)
                return NotFound();

            return Ok(videoGame);
        }

        [HttpPost]
        public ActionResult<VideoGame> CreateVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest("Video game cannot be null.");

            newGame.Id = videoGames.Max(vg => vg.Id) + 1;
            videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideoGame(int id, VideoGame updatedGame)
        {
            if (updatedGame is null)
                return BadRequest("Video game cannot be null.");

            var existingGame = videoGames.FirstOrDefault(vg => vg.Id == id);
            if (existingGame is null)
                return NotFound();

            existingGame.Title = updatedGame.Title;
            existingGame.Platform = updatedGame.Platform;
            existingGame.Developer = updatedGame.Developer;
            existingGame.Publisher = updatedGame.Publisher;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideoGame(int id)
        {
            var existingGame = videoGames.FirstOrDefault(vg => vg.Id == id);
            if (existingGame is null)
                return NotFound();

            videoGames.Remove(existingGame);
            return NoContent();
        }
    }
}
