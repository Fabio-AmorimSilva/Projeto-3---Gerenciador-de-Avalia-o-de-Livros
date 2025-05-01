namespace BookReviewManagement.Domain.Services.PasswordService;

public interface IPasswordHashService
{
    string HashPassword(string password);
}