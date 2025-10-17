using System.ComponentModel.DataAnnotations;

namespace Curate.Application.DTO.Auth.SignUp;

public class VerifyOtpDto
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public int Otp { get; set; }
}