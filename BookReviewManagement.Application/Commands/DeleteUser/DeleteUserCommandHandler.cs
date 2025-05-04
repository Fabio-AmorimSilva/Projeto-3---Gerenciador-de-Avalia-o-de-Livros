namespace BookReviewManagement.Application.Commands.DeleteUser;

public sealed class DeleteUserCommandHandler(IBookReviewManagementDbContext context) : IRequestHandler<DeleteUserCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user is null)
            return Result<Unit>.Error(ErrorMessages.NotFound<User>());
        
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return Result<Unit>.Success();
    }
}