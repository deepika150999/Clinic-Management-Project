using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        public IActionResult Getlogin()
        {
            return Ok(_db.Userpages.ToList());
        }
        [HttpPost]
        public IActionResult Login(Userpage user)
        {
            var result = (from i in _db.Userpages
                          where i.UserName == user.UserName && i.Password == user.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }

        }


    }
}
       



