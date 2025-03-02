namespace BookReviewManagement.Application.Queries.ListBooksReadCountOverTheYear;

public sealed class ListBooksReadCountOverTheYearQueryHandler(IBookReviewManagementDbContext context)
    : IRequestHandler<ListBooksReadCountOverTheYearQuery, Result<ListBooksReadCountOverTheYearViewModel>>
{
    public async Task<Result<ListBooksReadCountOverTheYearViewModel>> Handle(ListBooksReadCountOverTheYearQuery request, CancellationToken cancellationToken)
    {
        var booksCount = await context.Books
            .Where(b => b.CreatedAt.Year == DateTime.Now.Year)
            .CountAsync(cancellationToken);

        return Result<ListBooksReadCountOverTheYearViewModel>.Success(new ListBooksReadCountOverTheYearViewModel
        {
            BooksCount = booksCount
        });
    }
}