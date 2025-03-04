namespace BookReviewManagement.Domain.Extensions;

public static class UserExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        return
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
        ];
    }
}