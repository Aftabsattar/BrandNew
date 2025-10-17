namespace Curate.Application.DTO.Auth.SignUp;

public class UpdateUserDto
{
    public string Email { get; set; } = string.Empty;
    public int Passcode { get; set; }
    public DateTime PasscodeCreatedAt { get; set; }
}