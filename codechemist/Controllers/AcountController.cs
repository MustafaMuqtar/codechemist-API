using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using codechemist.Data.Entities;
using codechemist.Data.Services;
using codechemist.Models.ViewModels;

namespace codechemist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;


        public AcountController(UserManager<User> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserVM>> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                return Unauthorized();
            }



            return new UserVM
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            var user = new User { UserName = registerVM.Username, Email = registerVM.Email };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            return StatusCode(201);

        }


        [Authorize]
        [HttpGet("currentUser")]

        public async Task<ActionResult<UserVM>> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return new UserVM
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }
    }
}
