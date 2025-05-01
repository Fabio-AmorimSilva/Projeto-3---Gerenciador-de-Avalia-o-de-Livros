using Microsoft.JSInterop;

namespace BookReviewManagement.Blazor.Components.Pages.Books;

public partial class Index : ComponentBase
{
    [Inject] IJSRuntime JS { get; set; }
    
    [Inject] public NavigationManager Navigation { get; set; }

    [Inject] public IMediator Mediator { get; set; }

    [Inject] public IDialogService DialogService { get; set; }

    [Inject] public ISnackbar Snackbar { get; set; }

    public IEnumerable<ListBookViewModel> Books { get; set; } = [];

    private int ReadCountCurrentYear { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var books = await Mediator.Send(new ListBooksQuery());
        var readCount = await Mediator.Send(new ListBooksReadCountOverTheYearQuery());

        if (readCount.Data != null)
            ReadCountCurrentYear = readCount.Data.BooksCount;

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
        Navigation.NavigateTo($"books/{bookId}/update");
    }

    private void GoToReviews(Guid bookId)
    {
        Navigation.NavigateTo($"books/{bookId}/reviews");
    }

    private void GoToUpdateCover(Guid bookId)
    {
        Navigation.NavigateTo($"/books/{bookId}/update-cover");
    }
    
    private async Task<MemoryStream> GetFileStream()
    {
        var books = await Mediator.Send(new ListBooksReportsQuery());
        var fileStream = new MemoryStream(books.Data);

        return fileStream;
    }

    private async Task DownloadFileFromStream()
    {
        var fileStream = await GetFileStream();
        const string fileName = "books.pdf";

        using var streamRef = new DotNetStreamReference(stream: fileStream);

        await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
    }
}