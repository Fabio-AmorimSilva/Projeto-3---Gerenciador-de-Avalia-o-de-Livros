namespace BookReviewManagement.Application.Queries.ListBooks;

public sealed class ListBooksQueryHandler(IBookReviewManagementDbContext context) : IRequestHandler<ListBooksQuery, Result<IEnumerable<ListBookViewModel>>>
{
    public async Task<Result<IEnumerable<ListBookViewModel>>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await context.Books
            .Select(b => new ListBookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Isbn = b.Isbn,
                Author = b.Author,
                Publisher = b.Publisher,
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                Cover = ListBookViewModel.ConvertByteToString(b.Cover)
            })
            .ToListAsync(cancellationToken);

        return Result<IEnumerable<ListBookViewModel>>.Success(books);
    }
}