using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbMove.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoveAPI.Classes;

namespace MoveAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MoverController : Controller
    {
        private MoveContext _moveContext;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public MoverController(MoveContext moveContext, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _moveContext = moveContext;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mover>> Get()
        {
            return _moveContext.Movers.ToList();
        }

        [HttpGet("{moverId}")]
        public ActionResult<Mover> Get(long moverId)
        {
            return _moveContext.Movers.FirstOrDefault(x => x.Id == moverId);
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public ActionResult<Mover> Login(string username, string password)
        {
            var mover = _moveContext.Movers.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (mover == null)
            {
                return Unauthorized();
            }

            return Ok(mover);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public ActionResult<string> Authenticate([FromBody] UserCredentials user)
        {
            var token = jwtAuthenticationManager.Authenticate(user.Username, user.Password);
            var mover = _moveContext.Movers.FirstOrDefault(x => x.Username.ToLower() == user.Username.ToLower() && x.Password == user.Password);

            if (token == null && mover == null)
            {
                return Unauthorized();
            }

            return Ok(new { token, mover });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<OkResult> Register([FromBody] Mover user)
        {
            _moveContext.Add(user);
            await _moveContext.SaveChangesAsync();

            return Ok();
        }
    }
}