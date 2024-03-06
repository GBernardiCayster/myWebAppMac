

using myWebApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myWebApp.Data;
using myWebApp.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace myWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        SecurityDbContext _SecurityDbContext;

        public AccountController(SecurityDbContext SecurityDbContext)
        {
            _SecurityDbContext = SecurityDbContext;
        }

        [HttpPost("Login")]
        public ActionResult<UserSession> Login(LoginRequest loginRequest)
        {

            try
            {
                User? rk = _SecurityDbContext.Users.Find(loginRequest.UserName);

                if (rk.UserName == loginRequest.UserName && rk.Password == loginRequest.Password)
                {
                    //Valid UserName
                    UserSession? userSession = GenerateJwtToken(rk);

                    if (userSession is null)
                        return Unauthorized();
                    else
                        return userSession;
                }
                else {
                    return Unauthorized();
                }

            }
            catch
            {
                 return Unauthorized(); ;
            }

        }

        public UserSession? GenerateJwtToken(User user)
        {


            const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
            const int JWT_TOKEN_VALIDITY_MINS = 20;

            /* Generating JWT Token */
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                });
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            /* Returning the User Session object */
            var userSession = new UserSession
            {
                UserName = user.UserName,
                Role = user.Role,
                DataBaseId = user.DataBaseName,
                Token = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
            return userSession;
        }
    }
}
