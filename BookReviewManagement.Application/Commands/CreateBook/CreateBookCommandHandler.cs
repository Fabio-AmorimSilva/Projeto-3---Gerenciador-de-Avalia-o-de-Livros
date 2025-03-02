namespace BookReviewManagement.Application.Commands.CreateBook;

public sealed class CreateBookCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<CreateBookCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(
            title: request.Title,
            description: request.Description,
            isbn: request.Isbn,
            author: request.Author,
            publisher: request.Publisher,
            genre: request.Genre,
            publishDate: request.PublishDate,
            pages: request.Pages
        );

        var isbnAlreadyExists = await context.Books
            .WithSpecification(new IsbnAlreadyExistsSpec(book.Id, request.Isbn))
            .AnyAsync(cancellationToken);

        if (isbnAlreadyExists)
            return Result<Guid>.Error(ErrorMessages.IsbnAlreadyExists());

        await context.Books.AddAsync(book, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(book.Id);
    }
}