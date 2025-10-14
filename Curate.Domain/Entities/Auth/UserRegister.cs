namespace Curate.Domain.Entities.Auth;

public class UserRegister
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int Passcode { get; set; }
    public DateOnly CreateAt { get; set; }
    public  DateOnly UpdateAt { get; set; }
}