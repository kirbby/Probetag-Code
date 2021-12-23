using System.Collections.Generic;
using System.Linq;
using DbMove.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SportController : Controller
    {
        private MoveContext _moveContext;

        public SportController(MoveContext moveContext)
        {
            _moveContext = moveContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sport>> Get()
        {
            return _moveContext.Sports.ToList();
        }
    }
}