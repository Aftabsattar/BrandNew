namespace Curate.Domain.Entities.Auth;

public class OTP
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int Otp { get; set; } 
    public DateTime ExpireyTime { get; set; } 
    public bool IsUsed { get; set; }
}