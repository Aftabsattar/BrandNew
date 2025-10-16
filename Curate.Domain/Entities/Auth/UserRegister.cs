namespace Curate.Domain.Entities.Auth;

public class UserRegister
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateOnly CreateAt { get; set; }
    public  DateOnly UpdateAt { get; set; }
    public bool IsVerified { get; set; } = false;
    public bool IsProfileCompleted { get; set; } = false;
}