namespace BookReviewManagement.Blazor.Components.Pages.Users;

public partial class Index : ComponentBase
{
    [Inject]
    private IMediator Mediator { get; set; }
    [Inject]
    private NavigationManager Navigation { get; set; }
    [Inject]
    private ISnackbar Snackbar { get; set; }

    [Inject]
    private IDialogService DialogService { get; set; }
    
    public IEnumerable<ListUsersViewModel> Users = [];
    
    protected override async Task OnInitializedAsync()
    {
        var users = await Mediator.Send(new ListUsersQuery());
        
        Users = users.Data ?? [];
    }

    private async Task DeleteUserAsync(Guid id)
    {
        var result = await DialogService.ShowMessageBox(
            title: "Delete User",
            message: "Want to delete this user?",
            yesText: "Delete",
            noText: "No"
        );

        if (result is true)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            if(!response.IsSuccess)
                Snackbar.Add($"{response.Message}", Severity.Error);
            
            Snackbar.Add("User was deleted", Severity.Success);
            await OnInitializedAsync();
        }
    }
    
    private void GoToUpdate(Guid userId)
    {
        Navigation.NavigateTo($"/users/update/{userId}");
    }

    private void GoToReviews(Guid userId)
    {
        Navigation.NavigateTo($"/users/{userId}/reviews");
    }
}