namespace BookReviewManagement.Blazor.Components.Pages.Users;

public partial class IndexReviewsByUser : ComponentBase
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    [Inject]
    public IMediator Mediator { get; set; }
    
    [Inject]
    public ISnackbar Snackbar { get; set; }
    
    [Inject]
    public IDialogService DialogService { get; set; }
    
    [Parameter]
    public Guid UserId { get; set; }
    
    public IEnumerable<ListUserReviewsViewModel> Reviews { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        var reviews = await Mediator.Send(new ListUserReviewsQuery(UserId));
        
        Reviews = reviews.Data ?? [];
    }

    private async Task DeleteReviewAsync(Guid reviewId)
    {
        var result = await DialogService.ShowMessageBox(
            title: "Delete Review",
            message: "Delete this review?",
            yesText: "Delete",
            noText: "No"
        );

        if (result is true)
        {
            var response = await Mediator.Send(new DeleteReviewCommand(reviewId));

            if (!response.IsSuccess)
            {
                Snackbar.Add($"{response.Message}", Severity.Error);
            }
            else
            {
                Snackbar.Add($"Review is successfully deleted!!", Severity.Success);
                await OnInitializedAsync();
            }
        }
    }

    private void GoToUpdate(Guid reviewId)
    {
        Navigation.NavigateTo($"/update/reviews/{reviewId}");
    }
    
    
}