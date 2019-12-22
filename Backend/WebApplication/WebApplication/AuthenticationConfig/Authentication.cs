using Microsoft.IdentityModel.Tokens;
using System;

namespace T.AuthenticationConfig
{
    public class Authentication
    {
        public JwtBearer JwtBearer { get; set; }

    }
    public class JwtBearer
    {
        public bool IsEnabled { get; set; }

        public string SecurityKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
