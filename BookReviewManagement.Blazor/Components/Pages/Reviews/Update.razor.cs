namespace BookReviewManagement.Blazor.Components.Pages.Reviews;

public partial class Update : ComponentBase
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    [Inject]
    public IMediator Mediator { get; set; }
    
    [Inject]
    public IDialogService DialogService { get; set; }
    
    [Inject]
    public ISnackbar Snackbar { get; set; }
    
    [Parameter]
    public Guid ReviewId { get; set; }
    
    public ReviewUpdateModel ReviewUpdateModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        var response = await Mediator.Send(new GetReviewQuery(ReviewId));
        
        if(!response.IsSuccess)
            Snackbar.Add($"Error: {response.Message}", Severity.Error);

        var review = response.Data;

        if(review is not null)
        {
            ReviewUpdateModel = new ReviewUpdateModel
            {
                Description = review.Description,
                Score = review.Score
            };
        }
    }

    private async Task OnValidSubmitAsync(EditContext editContext)
    {
        if (editContext.Model is ReviewUpdateModel model)
        {
            var command = new UpdateReviewCommand
            (
                ReviewId: ReviewId,
                Description: model.Description,
                Score: model.Score
            );
            
            var response = await Mediator.Send(command);
            
            if(!response.IsSuccess)
                Snackbar.Add($"Error: {response.Message}", Severity.Error);
            
            Snackbar.Add("Review updated successfully!", Severity.Success);
            Navigation.NavigateTo($"/reviews/{ReviewId}/update");
        }
    }
}