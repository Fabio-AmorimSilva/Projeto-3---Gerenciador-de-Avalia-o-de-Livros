namespace BookReviewManagement.Application.Queries.GetBook;

public sealed class GetBookQueryHandler(IBookReviewManagementDbContext context) : IRequestHandler<GetBookQuery, Result<GetBookViewModel>>
{
    public async Task<Result<GetBookViewModel>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .Where(b => b.Id == request.BookId)
            .Select(b => new GetBookViewModel
            {
                Title = b.Title,
                Description = b.Description,
                Isbn = b.Isbn,
                Author = b.Author,
                Publisher = b.Publisher,
                Genre = b.Genre,
                PublishDate = b.PublishDate
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (book is null)
            return Result<GetBookViewModel>.Error(ErrorMessages.NotFound<Book>());

        return Result<GetBookViewModel>.Success(book);
    }
}