using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PageCss.ApplicationServices.Users;
using PageCss.Core.Entities;
using PageCss.Core.ViewModelsIn;
using Microsoft.AspNetCore.Cors;

namespace PageCss.Api.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;


        public AccountController(
            UserManager<User> userManager, 
            IUserService userService, 
            IConfiguration configuration
        )
        {
            _userManager = userManager;
            _configuration = configuration;
            _userService = userService;
        }


        // POST api/<UserController> LOGIN USER
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Ok(new
                {
                    hasError = true,
                    message = "User Unauthorized",
                    model = new { title = "User Unauthorized, password or/and user are incorrct" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }

            var roles = await _userManager.GetRolesAsync(user);

            // Generamos un token según los claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new
            {
                hasError = false,
                message = "Authorized",
                model = new { AccessToken = jwt },
                requestId = System.Diagnostics.Activity.Current?.Id
            });

        }

        // POST api/<UserController> ADD NEW USER
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsersViewModelIn value)
        {

            if (ModelState.IsValid)
            {
                IdentityResult result = await _userService.AddUserAsync(value);

                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        hasError = false,
                        message = "User Registered",
                        model = new { Email = value.Email, phoneNumber = value.PhoneNumber },
                        requestId = System.Diagnostics.Activity.Current?.Id
                    });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);

                    }
                    return Ok(new
                    {
                        hasError = true,
                        message = "Bad Request",
                        model = result.Errors,
                        requestId = System.Diagnostics.Activity.Current?.Id
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    hasError = true,
                    message = "Bad Request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
        }


    }
}
