using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DbMove.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveAPI.Models;

namespace MoveAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MoveController : Controller
    {
        private MoveContext _moveContext;

        public MoveController(MoveContext moveContext)
        {
            _moveContext = moveContext;
        }

        [AllowAnonymous]
        [HttpGet("GetOnDistance")]
        public ActionResult<IEnumerable<MoveViewModel>> GetOnDistance(long distanceInMeters, double latitude, double longitude)
        {
            var sqlQuery = "DECLARE @CurrentLocation geography;"
                    + " SET @CurrentLocation = geography::Point(" + latitude.ToString("0.000000000", CultureInfo.InvariantCulture)
                    + ", " + longitude.ToString("0.000000000", CultureInfo.InvariantCulture) + ", 4326)"
                    + " SELECT * , Round (geography::Point([Latitude], [Longitude], 4326).STDistance(@CurrentLocation ), 0) AS Distance"
                    + " FROM [Moves]"
                    + " WHERE geography::Point([Latitude], [Longitude], 4326).STDistance(@CurrentLocation ) <= " + distanceInMeters;
            var moves = _moveContext.Moves
                .FromSqlRaw(sqlQuery)
                 .ToList();

            return moves.Select(x => new MoveViewModel(x)).ToList();
        }

        [HttpGet("{moveId}")]
        public ActionResult<MoveViewModel> Get(long moveId)
        {
            return new MoveViewModel(_moveContext.Moves.FirstOrDefault(x => x.Id == moveId));
        }

        [HttpGet("GetOnMoverId/{moverId}")]
        public ActionResult<IEnumerable<MoveViewModel>> GetOnMoverId(long moverId)
        {
            var moveMovers = _moveContext.MoveMovers.Where(x => x.MoverId == moverId).ToList();
            var moveIds = moveMovers.Select(x => x.MoveId);
            var moves = _moveContext.Moves.Where(x => moveIds.Contains(x.Id)).ToList();

            return moves.Select(x => new MoveViewModel(x, moveMovers)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MoveViewModel move)
        {
            if (move == null)
            {
                return NotFound("Move was null!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            long.TryParse(User.Claims.First().Value, out var moverId);
            var dbMove = move.ToMove();

            await _moveContext.Moves.AddAsync(dbMove);
            await _moveContext.SaveChangesAsync();

            await _moveContext.MoveMovers.AddAsync(new MoveMover
            {
                MoveId = dbMove.Id,
                MoverId = moverId,
                ReadOnly = false
            });
            await _moveContext.SaveChangesAsync();

            return Ok(move);
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