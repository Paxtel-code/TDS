using Games.Api.Model;
using Games.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Games.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesItemController : ControllerBase{

        private readonly GamesContext _context;
        public GamesItemController(GamesContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<GamesModel>> ItemGames(){

            return _context.Games!.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamesModel?>> GamesByID(int id){

            return await _context.Games.Where(i => i.Id.Equals(id)).FirstAsync();
        }

        [HttpGet]
        public ActionResult<List<GamesModel>> Wishlist(){

            return _context.Games!.ToList().FindAll(g => g.Wish == true);
        }

        [HttpPost]
        public async Task<ActionResult<GamesModel>> Games(GamesModel games) {
            _context.Add(games);
            await _context.SaveChangesAsync();

            // return Created();
            return CreatedAtAction("Game", games);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<GamesModel>> Games(int id, GamesModel games) {
            if (id != games.Id) {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            // return Created();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GamesModel>> AddToWishlist(int id, string action) {

            _context.Entry(games).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            // return Created();
            return NoContent();
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<GamesModel>> GamesDelete(int id) {
            var games = await GamesByID(id);
            _context.Remove<GamesModel>(games.Value!);
            await _context.SaveChangesAsync();

            // return Created();
            return Ok();
        }
    }

}