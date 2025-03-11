namespace BookReviewManagement.Application.Commands.DeleteReview;

public sealed class DeleteReviewCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<DeleteReviewCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .Include(b => b.Reviews.Where(r => r.Id == request.ReviewId))
            .FirstOrDefaultAsync(cancellationToken);
        
        if (book is null)
            return Result<Unit>.Error(ErrorMessages.NotFound<Book>());
        
        var review = book.GetReview(request.ReviewId);

        if (review is null)
            return Result<Unit>.Error(ErrorMessages.NotFound<Review>());

        book.DeleteReview(review);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Result<Unit>.Success();
    }
}