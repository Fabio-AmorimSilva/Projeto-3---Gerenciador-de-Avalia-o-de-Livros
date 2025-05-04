namespace BookReviewManagement.Application.Commands.UpdateBookCover;

public sealed class UpdateBookCoverCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<UpdateBookCoverCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(UpdateBookCoverCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return Result<Guid>.Error(ErrorMessages.NotFound<Book>());

        book.UpdateCover(request.Cover);

        await context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(book.Id);
    }
}