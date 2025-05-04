namespace BookReviewManagement.Domain.Specifications;

public sealed class EmailAlreadyExistsSpec : Specification<User>
{
    public EmailAlreadyExistsSpec(Guid userId, string email)
    {
        Query.Where(u => u.Id != userId && u.Email == email);
    }
}