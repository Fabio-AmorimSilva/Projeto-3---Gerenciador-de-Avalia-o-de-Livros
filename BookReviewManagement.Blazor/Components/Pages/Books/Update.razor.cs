namespace BookReviewManagement.Blazor.Components.Pages.Books;

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
    public Guid BookId { get; set; }
    
    public BookUpdateModel BookUpdateModel { get; set; } = new();
    
    private async Task OnValidSubmitAsync(EditContext editContext)
    {
        if (editContext.Model is BookInputModel model)
        {
            var command = new UpdateBookCommand(
                BookId: BookId,
                Title: model.Title,
                Description: model.Description,
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
                Snackbar.Add("Book successfully updated!!", Severity.Success);
                Navigation.NavigateTo("/books");
            }
        }
        else
        {
            Snackbar.Add("An error occured.", Severity.Error);
        }
    }
}