namespace BookReviewManagement.Domain.Specifications;

public sealed class IsbnAlreadyExistsSpec : Specification<Book>
{
    public IsbnAlreadyExistsSpec(Guid bookId, string isbn)
    {
        Query.Where(b => b.Id != bookId && b.Isbn == isbn);
    }
}