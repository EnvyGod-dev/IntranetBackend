using Intranet.Services.AuthService.Data;
using Intranet.Services.AuthService.Models;
using Intranet.Services.AuthService.Models.DTO;
using Intranet.Services.AuthService.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Services.AuthService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }


        [HttpGet]
        public Object Get()
        {
            try
            {
                IEnumerable<User> obList = _db.Users.ToList();
                return obList;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO registerRequestDto)
        {
            if (ModelState.IsValid)
            {
                if (registerRequestDto.Password != registerRequestDto.ConfirmedPassword)
                {
                    return BadRequest("Нууц үг таарахгүй байна");
                }

                if (await _db.Users.AnyAsync(u => u.Email == registerRequestDto.Email || u.UserName == registerRequestDto.UserName))
                {
                    return BadRequest("Хэрэглэгч бүртгэлтэй байна");
                }

                var user = new User
                {
                    FirstName = registerRequestDto.FirstName,
                    LastName = registerRequestDto.LastName,
                    Email = registerRequestDto.Email,
                    UserName = registerRequestDto.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerRequestDto.Password),
                    CreatedAt = DateTime.Now,
                };

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                return Ok("Амжилттай бүртгүүллээ");
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginRequestDto)
        {
            if (ModelState.IsValid)
            {
                // Check Username Or Email either 
                var user = await _db.Users.SingleOrDefaultAsync(u =>
                    u.Email == loginRequestDto.UserIdentifier || u.UserName == loginRequestDto.UserIdentifier);

                if (user == null || !Secure.VerifyPassword(loginRequestDto.Password, user.Password))
                {
                    return Unauthorized("Имэйл/Хэрэглэгчийн нэр эсвэл нууц үг буруу байна");
                }

                var token = Secure.GenerateJwtToken(user.UserId.ToString(), user.UserName, _config["Jwt:Key"]);

                return Ok(new { Token = token });
            }
            return BadRequest(ModelState);
        }

    }
}
