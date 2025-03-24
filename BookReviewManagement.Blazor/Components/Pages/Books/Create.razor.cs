using BookReviewManagement.Blazor.Components.Pages.Books.Models;

namespace BookReviewManagement.Blazor.Components.Pages.Books;

public partial class Create : ComponentBase
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    [Inject]
    public IMediator Mediator { get; set; }
    
    [Inject]
    public IDialogService DialogService { get; set; }
    
    [Inject]
    public ISnackbar Snackbar { get; set; }
    
    public BookInputModel BookInputModel { get; set; } = new();

    private async Task OnValidSubmitAsync(EditContext editContext)
    {
        if (editContext.Model is BookInputModel model)
        {
            var command = new CreateBookCommand(
                Title: model.Title,
                Description: model.Description,
                Isbn: model.Isbn,
                Author: model.Author,
                Publisher: model.Publisher,
                Genre: model.Genre,
                PublishDate: model.PublishDate ?? DateTime.Today,
                Pages: model.Pages
            );
            
            var response = await Mediator.Send(command);

            if (!response.IsSuccess)
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
            else
            {
                Snackbar.Add("Book successfully created!!", Severity.Success);
                Navigation.NavigateTo("/books");
            }
        }
        else
        {
            Snackbar.Add("An error occured.", Severity.Error);
        }
    }
}