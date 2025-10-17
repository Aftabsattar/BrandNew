namespace Curate.Application.DTO.Auth.Login;

public class LoginWithPasscodeDto
{
    public string Email { get; set; } = string.Empty;
    public int Passcode { get; set; }
}