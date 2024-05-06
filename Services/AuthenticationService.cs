using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System;

namespace BLL.Services
{
    public class AuthenticationService : Interfaces.IAuthenticationService
    {
        private readonly IUser _userService;
        private readonly IConfiguration _config;

        public AuthenticationService(IUser userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        public async Task<AuthenticateResult> AuthenticateAsync(HttpContext httpContext, string username, string password)
        {
            var user = await _userService.GetUserByUsernameAndPasswordAsync(username, password);
            if (user == null)
            {
                return AuthenticateResult.Fail("Authentication failed.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(securityToken);

            var identity = new ClaimsIdentity(claims, "Bearer");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Bearer");

            return AuthenticateResult.Success(ticket);
        }
    }
}
