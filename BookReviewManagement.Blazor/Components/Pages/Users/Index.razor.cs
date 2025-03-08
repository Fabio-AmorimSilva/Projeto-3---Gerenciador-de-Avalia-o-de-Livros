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
}