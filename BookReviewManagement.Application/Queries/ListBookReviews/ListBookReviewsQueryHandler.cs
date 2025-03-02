namespace BookReviewManagement.Application.Queries.ListBookReviews;

public sealed class ListBookReviewsQueryHandler(IBookReviewManagementDbContext context) : IRequestHandler<ListBookReviewsQuery, Result<IEnumerable<ListBookReviewsViewModel>>>
{
    public async Task<Result<IEnumerable<ListBookReviewsViewModel>>> Handle(ListBookReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await context.Books
            .SelectMany(b => b.Reviews.Where(b => b.Id == request.BookId))
            .Select(r => new ListBookReviewsViewModel
            {
                Title = r.Book.Title,
                Isbn = r.Book.Isbn,
                Description = r.Description,
                Score = r.Score
            })
            .ToListAsync(cancellationToken);
        
        return Result<IEnumerable<ListBookReviewsViewModel>>.Success(reviews);
    }
}