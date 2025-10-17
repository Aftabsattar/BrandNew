namespace Curate.Domain.Entities.Auth;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateOnly CreateAt { get; set; }
    public  DateOnly UpdateAt { get; set; }
    public bool IsVerified { get; set; } = false;
    public bool IsProfileCompleted { get; set; } = false;
    public int Otp { get; set; }
    public DateTime ExpireyTime { get; set; }
    public bool IsUsed { get; set; }
    public int Passcode { get; set; }
    public DateTime PasscodeCreatedAt { get; set; }
}