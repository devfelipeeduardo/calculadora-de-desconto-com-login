namespace Fase5_CalculadoraDeDescontoComLogin.Models.Entities;

internal class User
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string PhoneNumber { get; set; }
    public User() { }
}
