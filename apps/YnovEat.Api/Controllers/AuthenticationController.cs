using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YnovEat.Api.Core.Response;
using YnovEat.Api.Core.Response.Errors;
using YnovEat.Application.DTO.UserModels;
using YnovEat.Application.DTO.UserModels.Registration;
using YnovEat.Application.Services;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEatApi.Core.UserModels;

namespace YnovEat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IRegistrationService _registrationService;

        public AuthenticationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, IRegistrationService registrationService) : base(userManager, configuration)
        {
            _registrationService = registrationService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);
            if (user == null || !await UserManager.CheckPasswordAsync(user, model.Password)) return Unauthorized();

            var userRoles = await UserManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecret"]));

            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:ValidIssuer"],
                audience: Configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("init-super-admin/{pass}")]
        public async Task<IActionResult> InitSuperAdmin([FromRoute] string pass, [FromBody] RegisterSuperAdminDto model)
        {
            if (pass != Configuration["InitAdminPass"]) return Unauthorized();

            return await RegisterUser(model);
        }

        [Core.Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPost]
        [Route("register-super-admin")]
        public async Task<IActionResult> RegisterSuperAdmin([FromBody] RegisterSuperAdminDto model)
        {
            return await RegisterUser(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register-restaurantAdmin")]
        public async Task<IActionResult> RegisterRestaurantAdmin([FromBody] RegisterRestaurantAdminDto model)
        {
            return await RegisterUser(model);
        }

        [Core.Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpPost]
        [Route("register-employee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterEmployeeDto model)
        {
            return await RegisterUser(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register-customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto model)
        {
            return await RegisterUser(model);
        }

        [Core.Authorize]
        [HttpGet("current-user")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var currentUser = await GetAuthenticatedUserDto();
            if (currentUser == null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new InvalidTokenErrorResponse()
                );

            return currentUser;
        }

        private async Task CheckUserNonexistence(string username)
        {
            var userExists = await UserManager.FindByNameAsync(username);
            if (userExists != null) throw new Exception("User already exists");
        }

        private async Task<IActionResult> RegisterUser<T>(T model) where T : RegisterUserDto
        {
            try
            {
                await CheckUserNonexistence(model.Username);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response {Status = ResponseStatus.Error, Message = e.Message});
            }

            try
            {
                var userDto = await _registrationService.Register(model);

                return StatusCode(
                    StatusCodes.Status201Created,
                    userDto
                );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    {
                        Status = ResponseStatus.Error,
                        Message = "User creation failed! Please check user details and try again."
                    });
            }
        }
    }
}
