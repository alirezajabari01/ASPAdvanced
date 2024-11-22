namespace Shop.Application.Contract.Dtos.Users;

public record RegisterDto
{
    public string UserName { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string ConfirmPassword { get; init; } = null!;
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

