namespace BookReviewManagement.Application.Queries.GetUser;

public sealed class GetUserQueryHandler(IBookReviewManagementDbContext context) : IRequestHandler<GetUserQuery, Result<GetUserViewModel>>
{
    public async Task<Result<GetUserViewModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Where(u => u.Id == request.UserId)
            .Select(u => new GetUserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
            return Result<GetUserViewModel>.Error(ErrorMessages.NotFound<User>());

        return Result<GetUserViewModel>.Success(user);
    }
}