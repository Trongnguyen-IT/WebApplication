using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace T.AuthenticationConfig
{
    public static class AuthenticationConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection(nameof(Authentication));
            services.Configure<Authentication>(appSettingsSection);

            // configure jwt authentication
            var authenticationSetting = appSettingsSection.Get<Authentication>();
            var key = Encoding.ASCII.GetBytes(authenticationSetting.JwtBearer.SecurityKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = false,
                    ValidIssuer = authenticationSetting.JwtBearer.Issuer,

                    ValidateAudience = false,
                    ValidAudience = authenticationSetting.JwtBearer.Audience,

                    ValidateLifetime = true,
                };

            });
        }
    }
}
