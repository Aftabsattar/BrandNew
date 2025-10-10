namespace Curate.Domain.Entities.Auth;

public class User
{
    public int id { get; set; }
    public string ProfileUrl{ get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public string Gender { get; set; } = string.Empty;
}