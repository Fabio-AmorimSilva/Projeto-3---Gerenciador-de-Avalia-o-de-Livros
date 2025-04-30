namespace BookReviewManagement.Application.Queries.ListBooksReports;

public sealed class ListBooksReportsQueryHandler(
    IReportsService service
) : IRequestHandler<ListBooksReportsQuery, Result<byte[]>>
{
    public async Task<Result<byte[]>> Handle(ListBooksReportsQuery request, CancellationToken cancellationToken)
    {
        var pdf = await service.GeneratePdf();

        return Result<byte[]>.Success(pdf);
    }
}