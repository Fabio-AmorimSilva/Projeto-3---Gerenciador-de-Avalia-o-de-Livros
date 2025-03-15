namespace BookReviewManagement.Blazor.Components.Pages.Books;

public partial class Index : ComponentBase
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    [Inject]
    public IMediator Mediator { get; set; }
    
    [Inject]
    public IDialogService DialogService { get; set; }
    
    [Inject]
    public ISnackbar Snackbar { get; set; }

    public IEnumerable<ListBookViewModel> Books { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        var books = await Mediator.Send(new ListBooksQuery());
        
        Books = books.Data ?? [];
    }

    private async Task DeleteBook(Guid bookId)
    {
        var result = await DialogService.ShowMessageBox(
            title: "Delete",
            message: "Delete this book?",
            yesText: "Delete",
            noText: "No"
        );

        if (result is true)
        {
            var response = await Mediator.Send(new DeleteBookCommand(bookId));

            if (!response.IsSuccess)
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
            else
            {
                Snackbar.Add("Book successfully deleted!!", Severity.Success);
                await OnInitializedAsync();
            }
        }
    }

    private void GoToUpdate(Guid bookId)
    {
        Navigation.NavigateTo($"books/update/{bookId}");
    }
    
    private void GoToReviews(Guid bookId)
    {
        Navigation.NavigateTo($"books/{bookId}/reviews");
    }
}