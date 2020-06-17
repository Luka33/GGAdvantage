using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GGAdvantage.Application;
using GGAdvantage.Application.Interfaces;
using GGAdvantage.Application.Models;
using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using GGAdvantage.Application.Models.User;
using GGAdvantage.Domain.Entities;
using GGAdvantage.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GGAdvantage.Web.Api.Controllers
{
     //UserName = "luka",
     //Password = "luka123"
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserController(IUnitOfWork unitOfWork, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserRegisterRequestDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userRegisterDto.UserName);

                if (user == null)
                {
                    user = new AppUser
                    {
                        UserName = userRegisterDto.UserName
                    };

                    var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
                }

                return Ok(new UserDto { UserName = user.UserName });
            }

            return NotFound();
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<ActionResult> Login(UserLoginRequestDto userLoginDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
        //    }



        //    return null;
        //}

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(true);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequestDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        // create token
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _configuration["JwtSettings:Issuer"],
                            _configuration["JwtSettings:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(1),
                            signingCredentials: credentials
                        );

                        var response = new UserLoginResponseDto
                        {
                            User = new UserDto
                            {
                                UserName = user.UserName
                            },
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            TokenExpiration = token.ValidTo
                        };
                       
                        return Created("", response);
                    }
                }

                ModelState.AddModelError("", "Failed to login");
                return BadRequest(ModelState);

            }

            return BadRequest(ModelState);
        }
    }
}
