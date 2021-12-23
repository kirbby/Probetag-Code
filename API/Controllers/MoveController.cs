using System.Linq;
using System.Threading.Tasks;
using DbMove.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoveController : Controller
    {
        private MoveContext _moveContext;

        public MoveController(MoveContext moveContext)
        {
            _moveContext = moveContext;
        }

        [HttpGet("MakeCopyOfMove/{moveId}")]
        public async Task<ActionResult> make_copy_of_move(long moveId)
        {
            var move_to_copy = _moveContext.Moves.FirstOrDefault(x => x.Id == moveId);

            await _moveContext.AddAsync(_moveContext.Entry(move_to_copy).CurrentValues.ToObject());

            return Ok(moveId);
        }

        [HttpGet("ToggleSubscribe/{moveId}")]
        public async Task<ActionResult> ToggleSubscribe(long moveId)
        {
            if (moveId == 0)
            {
                return NotFound("Move was null!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            long.TryParse(User.Claims.First().Value, out var moverId);

            var moveMover = _moveContext.MoveMovers.FirstOrDefault(x => x.MoveId == moveId && x.MoverId == moverId);
            var subscribed = false;

            if (moveMover != null)
            {
                _moveContext.MoveMovers.Remove(moveMover);
            }
            else
            {
                var newMoveMover = new MoveMover
                {
                    MoveId = moveId,
                    MoverId = moverId,
                    ReadOnly = true
                };

                await _moveContext.MoveMovers.AddAsync(newMoveMover);
                subscribed = true;
            }

            await _moveContext.SaveChangesAsync();

            return Ok(subscribed);
        }
    }
}