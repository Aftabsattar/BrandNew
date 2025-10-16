using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Curate.Application.IServices;
using Curate.Domain.Entities.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Curate.Infrastructre.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(UserRegister userRegister)
    {
        var JwtSetting = _configuration.GetSection("Jwt");
        var key = JwtSetting["Key"];
        var Issuer = JwtSetting["Issuer"];
        var Audience = JwtSetting["Audience"];
        var sub = JwtSetting["sub"];
        var ExpiryMinutes = JwtSetting["ExpiryMinutes"];

        var Claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userRegister.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userRegister.Email),
            new Claim("IsProfileCompleted", userRegister.IsProfileCompleted.ToString())
        };

        var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var Credentials = new SigningCredentials(SecurityKey,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            expires: DateTime.UtcNow.AddMinutes(10),
            claims:Claims,
            signingCredentials: Credentials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}