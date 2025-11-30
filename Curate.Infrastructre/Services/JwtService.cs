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

    public string GenerateJwtToken(User userRegister)
    {
        var JwtSetting = _configuration.GetSection("Jwt");
        var key = JwtSetting["Key"];
        var Issuer = JwtSetting["Issuer"];
        var Audience = JwtSetting["Audience"];
        var sub = JwtSetting["sub"];
        var role = JwtSetting["Role"];
        var ExpiryMinutes = JwtSetting["DurationInMinutes"];

        var Claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userRegister.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userRegister.Email),
            new Claim("IsProfileCompleted", userRegister.IsProfileCompleted.ToString()),
            new Claim(ClaimTypes.Role, userRegister.Role)
        };

        var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var Credentials = new SigningCredentials(SecurityKey,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            expires: DateTime.UtcNow.AddHours(10),
            claims:Claims,
            signingCredentials: Credentials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}