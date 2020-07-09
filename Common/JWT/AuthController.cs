using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.JWT
{

    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenManger _appsettingsModel;
        //若要使用热更新，则入参调整为 IOptionsSnapshot<T>
        public AuthController(IOptions<TokenManger> appsettingsModel)
        {
            _appsettingsModel = appsettingsModel.Value;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            string userName = "@peng";
            var claims = new[]
                 {
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                    new Claim(ClaimTypes.Name, userName)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsettingsModel.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                   issuer: _appsettingsModel.Issuer,
                   audience: _appsettingsModel.Audience,
                   claims: claims,
                   expires: DateTime.Now.AddMinutes(30),
                   signingCredentials: creds);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            }); ;
        }
    }
}
