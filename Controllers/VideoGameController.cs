using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {

        private readonly VideoGameDbContext _context = context;
       
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {

            var game = await _context.VideoGames.FindAsync(id);

            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);

        }


        [HttpPost]

        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newgame)
        {
            if (newgame is null)
            {
                return BadRequest();
            }

            _context.VideoGames.Add(newgame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newgame.Id }, newgame);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatedVideoGame(int id, VideoGame updatedGame)
        {
            var game = await _context.VideoGames.FindAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return BadRequest();
            }

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
