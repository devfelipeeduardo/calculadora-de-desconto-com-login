namespace Fase5_CalculadoraDeDescontoComLogin.Models.Models;

public class User
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string PhoneNumber { get; set; }
    public User() { }
}
