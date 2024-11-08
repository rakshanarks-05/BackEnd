using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.DTO;
using TaskManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly TaskContext _context;

        public UserLoginController(TaskContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDTO userDTO)
        {
            try
            {
                var userReq = new UserLogin
                {
                    FullName = userDTO.FullName,
                    Email = userDTO.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.Password),
                    Role = userDTO.Role,
                };
                var data = await _context.UsersLogin.AddAsync(userReq);
                await _context.SaveChangesAsync();
                var Req = new UserDTO
                {
                    FullName = data.Entity.FullName,
                    Email = data.Entity.Email,
                    Role = data.Entity.Role,
                };
                return Ok(Req);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult>Login(string Email , string Password)
        {
            try
            {
                var user = await _context.UsersLogin.FirstOrDefaultAsync(x => x.Email == Email);
                if (user == null)
                {
                    throw new Exception("Users Not Found");
                }
                var Invalid = BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash);
                if (!Invalid)
                {
                    throw new Exception("Invalid Password Or Email..");
                }
                var res = new UserDTO
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role,
                };
                return Ok(res);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }

        }


    }
}
