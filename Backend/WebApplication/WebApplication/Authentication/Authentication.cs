using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using T.Core;
using T.Core.Shared;
using T.EntityFrameworkCore;

namespace T.Host.Token
{
    public class Authentication : IAuthentication
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        private readonly AuthenticationConfig.Authentication appSettings;
        private readonly TDbContext context;

        public Authentication(IOptions<AuthenticationConfig.Authentication> appSettings,
            TDbContext context)
        {
            this.appSettings = appSettings.Value;
            this.context = context;
        }

        //[Produces("application/json")]
        public async Task<ApiExcuteResult> Authenticate(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return new ApiExcuteResult
                {
                    Status = ApiStatus.Fail,
                    Message = "Username or password is incorrect"
                };

            var accessToken = CreateAccessToken(user, TimeSpan.FromDays(7));
            //user.Token = accessToken;

            // remove password before returning
            user.Password = null;

            return new ApiExcuteResult
            {
                Status = ApiStatus.Success,
                Data = new { token = accessToken }
            };
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        //private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        private string CreateAccessToken(User user, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.JwtBearer.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Issuer = appSettings.JwtBearer.Issuer,
                Audience = appSettings.JwtBearer.Audience,
                Expires = now.Add(expiration ?? TimeSpan.FromDays(7)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
