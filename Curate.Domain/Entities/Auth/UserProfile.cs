namespace Curate.Domain.Entities.Auth;

public class UserProfile
{
    public int id { get; set; }
    public string ProfileUrl{ get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Passcode { get; set; } 
    public int PhoneNumber { get; set; }
    public string Gender { get; set; } = string.Empty;
}