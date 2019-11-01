using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ReferMe.Model.DTO;

namespace ReferMe.API.Auth
{
    public static class JwtAuthManager
    {
        public const string SecretKey = "JIOBLi6eVjBpvGtWBgJzjWd2QH0sOn5tI8rIFXSHKijXWEt/3J2jFYL79DQ1vKu+EtTYgYkwTluFRDdtF41yAQ==";
        public static string GenerateJWTToken(UserDTO user, int expire_in_Minutes = 10)
        {
            var symmetric_Key = Convert.FromBase64String(SecretKey);
            var token_Handler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var securitytokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                    new Claim("UserID",user.UserID.ToString()),
                    new Claim("EmailAddress",user.EmailAddress),
                    new Claim("UserRole",user.UserRole),
                    new Claim("FirstName",user.FirstName),
                    new Claim("MiddleName",user.MiddleName),
                    new Claim("LastName",user.LastName),
                    new Claim("Mobile",user.Mobile)
                        }),

                Expires = now.AddMinutes(Convert.ToInt32(expire_in_Minutes)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetric_Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = token_Handler.CreateToken(securitytokenDescriptor);
            var token = token_Handler.WriteToken(stoken);

            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(SecretKey);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}