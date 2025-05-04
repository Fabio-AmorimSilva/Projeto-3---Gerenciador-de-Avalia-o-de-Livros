namespace BookReviewManagement.Domain.Services.Reports;

public interface IReportsService
{
    Task<byte[]> GeneratePdf();
}