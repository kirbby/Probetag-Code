using System.Collections.Generic;
using System.Linq;
using DbMove.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoveAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MediaController : Controller
    {
        private MoveContext _moveContext;

        public MediaController(MoveContext moveContext)
        {
            _moveContext = moveContext;
        }

        [HttpGet]
        public ActionResult<Media> Get(long mediaId)
        {
            return _moveContext.Medias.FirstOrDefault(x => x.Id == mediaId);
        }
    }
}