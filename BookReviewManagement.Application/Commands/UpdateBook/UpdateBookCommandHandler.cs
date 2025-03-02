namespace BookReviewManagement.Application.Commands.UpdateBook;

public sealed class UpdateBookCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<UpdateBookCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return Result<Unit>.Error(ErrorMessages.NotFound<Book>());

        book.Update(
            title: request.Title,
            description: request.Description,
            author: request.Author,
            publisher: request.Publisher,
            genre: request.Genre,
            pages: request.Pages,
            publishDate: request.PublishDate
        );

        await context.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success();
    }
}