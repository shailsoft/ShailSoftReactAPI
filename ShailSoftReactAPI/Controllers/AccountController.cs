using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShailSoftReactAPI.Data;
using ShailSoftReactAPI.Models;

namespace ShailSoftReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ShailSoftReactAPIContext _context;

        public AccountController(ShailSoftReactAPIContext context)
        {
            _context = context;
        }

        // GET: api/Student/5
        [HttpGet("Login/{email}/{password}")]
        public async Task<ActionResult<Student>> Login(string email, string password)
        {
            var student = await (from obj in _context.Student
                                 where obj.Email == email & obj.Password == password
                                 select obj).FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
    }
}
