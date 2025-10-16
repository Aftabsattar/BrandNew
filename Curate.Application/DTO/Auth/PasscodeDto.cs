namespace Curate.Application.DTO.Auth;

public class PasscodeDto
{
    public string Email { get; set; } = string.Empty;
    public int Passcode { get; set; }
    public DateTime CreateAt { get; set; } 
    public DateTime UpdateAt { get; set; }
}