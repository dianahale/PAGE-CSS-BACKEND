using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PageCss.ApplicationServices.Users;
using PageCss.Core.ViewModelsIn;

namespace PageCss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
