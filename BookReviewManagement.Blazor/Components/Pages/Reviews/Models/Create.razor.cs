namespace BookReviewManagement.Blazor.Components.Pages.Reviews.Models;

public partial class Create : ComponentBase
{
    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    [Inject]
    public IMediator Mediator { get; set; } = null!;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    public ReviewInputModel ReviewInputModel { get; set; } = new();
    private IEnumerable<ListBookViewModel> Books { get; set; } = [];

    private async Task OnValidSubmitAsync(EditContext editContext)
    {
        if (editContext.Model is ReviewInputModel model)
        {
            var command = new CreateReviewCommand
            (
                BookId: model.BookId,
                Score: model.Score,
                Description: model.Description
            );
            
            var response = await Mediator.Send(command);

            if (!response.IsSuccess)
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
            else
            {
                Snackbar.Add("Review successfully created!!", Severity.Success);
                Navigation.NavigateTo($"/books/{model.BookId}/reviews");
            }
        }else
        {
            Snackbar.Add("An error occured.", Severity.Error);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var books = await Mediator.Send(new ListBooksQuery());
        
        Books = books.Data ?? [];
    }
}