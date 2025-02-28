namespace BookReviewManagement.Application.Commands.DeleteBook;

public sealed class DeleteBookCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<DeleteBookCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return Result<Unit>.Error(ErrorMessages.NotFound<Book>());

        context.Books.Remove(book);
        await context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}