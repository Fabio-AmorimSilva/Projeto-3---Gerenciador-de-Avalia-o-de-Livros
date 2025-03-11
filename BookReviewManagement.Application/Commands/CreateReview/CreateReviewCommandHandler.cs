namespace BookReviewManagement.Application.Commands.CreateReview;

public sealed class CreateReviewCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<CreateReviewCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user is null)
            return Result<Guid>.Error(ErrorMessages.NotFound<User>());
        
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return Result<Guid>.Error(ErrorMessages.NotFound<Book>());
        
        var review = new Review(
            user: user,
            book: book,
            score: request.Score,
            description: request.Description
        );
        
        user.AddReview(review);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Result<Guid>.Success(review.Id);
    }
}