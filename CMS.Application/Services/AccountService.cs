using CMS.Application.ApiModels;
using CMS.Application.Exceptions;
using CMS.Application.Helpers;
using CMS.Application.Interfaces;
using CMS.Core.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMS.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public JwtSettings _jwtSettings;
        public AccountService(IAccountRepository accountRepository, IOptions<JwtSettings> jwtsettings)
        {
            _accountRepository = accountRepository;
            _jwtSettings = jwtsettings.Value;
        }
        public UserLoginResponse Authenticate(string userName, string password)
        {
            string token = string.Empty;
            UserLoginResponse userLoginResponse = null;
            var user = _accountRepository.Authenticate(userName, password);
            if(user == null)
            {
                throw new ApiException("User not found in the system", 404);
            }
            else
            {
                token = GenerateJwtToken(user.UserName, user.UserTypes.UserType);
                userLoginResponse = new UserLoginResponse
                {
                    UserName = user.UserName,
                    UserType = user.UserTypes.UserType,
                    Token = token
                };
            }
            return userLoginResponse;
        }

        /// <summary>
        /// Generate JWT token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public string GenerateJwtToken(string userName, string Role)
        {
            string token = string.Empty;

            try
            {
                //var jwtSettings = new JwtSettings();
                ////Attempts to bind the given object instance to configuration values by matching property names against configuration keys recursively.
                //IConfiguration.Bind("JwtSettings", jwtSettings);

                //I have a security key which is essentially used to “sign” the token on it’s way out.
                //We can verify this signature when we receive the token on the other end to make sure it was created by us.
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var issuer = _jwtSettings.Issuer; //Issuer is “who” created this token
                var audience = _jwtSettings.Audience; //Audience is “who” the token is supposed to be read(Validate) by

                //var claims = new List<Claim>();
                //claims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
                //claims.Add(new Claim("Role", Role));

                //if I log into  as an administrator role,
                //then my token might have a “claim” that my role is administrator
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim("Role", Role)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = credentials
                };

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);

                token = tokenHandler.WriteToken(securityToken);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return token;
        }

    }
}
