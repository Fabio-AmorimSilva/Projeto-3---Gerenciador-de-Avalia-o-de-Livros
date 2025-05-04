namespace BookReviewManagement.Domain.Services.TokenService;

public interface ITokenService
{
    string GenerateToken(User user);
}