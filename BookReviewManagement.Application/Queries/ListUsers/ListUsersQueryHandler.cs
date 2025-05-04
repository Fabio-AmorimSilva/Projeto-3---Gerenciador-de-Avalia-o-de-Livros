namespace BookReviewManagement.Application.Queries.ListUsers;

public sealed class ListUsersQueryHandler(IBookReviewManagementDbContext context) : IRequestHandler<ListUsersQuery, Result<IEnumerable<ListUsersViewModel>>>
{
    public async Task<Result<IEnumerable<ListUsersViewModel>>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await context.Users
            .Select(u => new ListUsersViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .ToListAsync(cancellationToken);

        return Result<IEnumerable<ListUsersViewModel>>.Success(users);
    }
}