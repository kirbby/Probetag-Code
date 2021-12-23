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
    public class SportController : Controller
    {
        private MoveContext _moveContext;

        public SportController(MoveContext moveContext)
        {
            _moveContext = moveContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Sport>> Get()
        {
            return _moveContext.Sports.ToList();
            // return new List<Sport>{
            //    new Sport{
            //        Id = 1,
            //        Name = "Fußball"
            //    },
            //    new Sport{
            //        Id = 2,
            //        Name = "Tennis"
            //    },
            //    new Sport{
            //        Id = 3,
            //        Name = "Laufen"
            //    }
            // };
        }
    }
}