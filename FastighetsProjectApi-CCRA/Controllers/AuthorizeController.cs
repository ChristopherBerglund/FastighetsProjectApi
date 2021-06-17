using FastighetsProjectApi_CCRA.Areas.Identity.Data;
using FastighetsProjectApi_CCRA.Data;
using FastighetsProjectApi_CCRA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Controllers
{
    [Route("Api/Account")]
    public class AuthorizeController : Controller
    {
        private readonly FastighetsProjectApi_CCRAContext dbContext;
        private readonly DbContext context;
        private readonly UserManager<FastighetsProjectApi_CCRAUser> userManager;
        private readonly SignInManager<FastighetsProjectApi_CCRAUser> signInManager;

        public AuthorizeController(FastighetsProjectApi_CCRAContext dbContext,
            DbContext context,
            UserManager<FastighetsProjectApi_CCRAUser> userManager,
            SignInManager<FastighetsProjectApi_CCRAUser> signInManager)
        {
            this.dbContext = dbContext;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //[Route("api/token")] // Vi vill ha register som sin egen adress.. oklart
        [HttpPost("Token")] 
        [AllowAnonymous]
        public async Task<ActionResult> GetToken([FromBody] MyLoginModelType myLoginModel)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Email == myLoginModel.Email);
            if (user != null)
            {
                var signInResult = await signInManager.CheckPasswordSignInAsync(user, myLoginModel.Password, false);
                if (signInResult.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("Krypterings_nyckel_ubwHBJHgirbIBHIBH768Bhfbehbkvs%&/()");
                    var tokenDescriptior = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, myLoginModel.Email)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptior);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Ok("Failed, try again");
                }
            }
            return Ok("Failed, try again");

        }
      
       
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] MyLoginModelType myLoginModel)
        {
            var fastighetsProjectApi_CCRAUser = new FastighetsProjectApi_CCRAUser()
            {
                Email = myLoginModel.Email,
                UserName = myLoginModel.Email,
                EmailConfirmed = false      //We dont need e-mail confirmation of new user ID.
            };

            var result = await userManager.CreateAsync(fastighetsProjectApi_CCRAUser, myLoginModel.Password);

            if (result.Succeeded)
            {

                /////////////////////////////////
                var user = new User()
                {
                    UserName = myLoginModel.Email
                };
                context.Users.Add(user);
                context.SaveChanges();
                /////////////////////////////////
                
                return Ok(new { Result = "Register Success" });

               
            }
            else
            {
                StringBuilder errorString = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errorString.Append(error.Description);
                }
                return Ok(new { Result = $"Register fail: {errorString.ToString()}" });
            }
        }

    }
}
