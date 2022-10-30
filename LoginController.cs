using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoneClinicApi.Models;

namespace StoneClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       
            private readonly StoneClinicContext _db;
            public LoginController(StoneClinicContext db)
            {
                _db = db;

            }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userpage>>> GetUser()
        {

            return await _db.Userpages.ToListAsync();
        }

     }
    }