namespace BookReviewManagement.Blazor.Components.Pages.Users;

public partial class Update : ComponentBase
{
    [Parameter] 
    public Guid UserId { get; set; }

    [Inject] 
    private IMediator Mediator { get; set; }
    [Inject] 
    private NavigationManager Navigation { get; set; }
    [Inject] 
    private ISnackbar Snackbar { get; set; }
    
    public UserUpdateModel UserUpdateModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        var response = await Mediator.Send(new GetUserQuery(UserId));

        if (!response.IsSuccess)
            Snackbar.Add($"{response.Message}", Severity.Error);

        UserUpdateModel = new UserUpdateModel
        {
            Name = response.Data!.Name,
            Email = response.Data.Email
        };
    }

    public async Task UpdateUser(EditContext editContext)
    {
        if (editContext.Model is UserUpdateModel model)
        {
            var response = await Mediator.Send(new UpdateUserCommand(
                Id: UserId,
                Name: model.Name,
                Email: model.Email
            ));

            if (!response.IsSuccess)
                Snackbar.Add($"{response.Message}", Severity.Error);

            Snackbar.Add("User was successfully updated!!", Severity.Success);
            Navigation.NavigateTo("/users");
        }
    }
}