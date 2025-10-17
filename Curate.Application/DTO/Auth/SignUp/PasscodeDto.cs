namespace Curate.Application.DTO.Auth.SignUp;

public class PasscodeDto
{
    public string Email { get; set; } = string.Empty;
    public int Passcode { get; set; }
    public DateTime PasscodeCreateAt { get; set; }
}