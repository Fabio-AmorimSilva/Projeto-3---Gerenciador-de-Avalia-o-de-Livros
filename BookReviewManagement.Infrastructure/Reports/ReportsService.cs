namespace BookReviewManagement.Infrastructure.Reports;

public sealed class ReportsService(
    IBookReviewManagementDbContext context
) : IReportsService
{
    public async Task<byte[]> GeneratePdf()
    {
        var books = await context.Books
            .AsNoTracking()
            .Include(b => b.Reviews)
            .Select(b => new BooksReportsModel
            {
                 Id = b.Id,
                 Title = b.Title,
                 Description = b.Description,
                 Isbn = b.Isbn,
                 Author = b.Author,
                 Publisher = b.Publisher,
                 Genre = b.Genre,
                 PublishDate = b.PublishDate,
                 Score = b.AverageScore(),
                 Cover = b.Cover
            })
            .ToListAsync();
        
        var pdf = BooksReport.GeneratePdfBooks(books);

        return pdf;
    }
}