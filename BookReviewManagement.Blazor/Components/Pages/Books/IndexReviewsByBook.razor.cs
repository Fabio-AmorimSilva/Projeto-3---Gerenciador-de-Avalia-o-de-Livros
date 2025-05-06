namespace BookReviewManagement.Blazor.Components.Pages.Books;

public partial class IndexReviewsByBook : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }
    
    [Inject]
    public IDialogService DialogService { get; set; }
    
    [Inject]
    public ISnackbar Snackbar { get; set; }
    
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    [Parameter]
    public Guid BookId { get; set; }

    public IEnumerable<ListBookReviewsViewModel> Reviews = [];

    protected override async Task OnInitializedAsync()
    {
        var reviews = await Mediator.Send(new ListBookReviewsQuery(BookId));
        
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
        NavigationManager.NavigateTo($"/reviews/{reviewId}/update");
    }
}