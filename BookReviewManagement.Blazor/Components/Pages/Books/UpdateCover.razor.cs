namespace BookReviewManagement.Blazor.Components.Pages.Books;

public partial class UpdateCover : ComponentBase
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

    private BookUpdateCoverModel BookUpdateCoverModel { get; set; } = new();

    private string _imagePreview = null!;
    
    private async Task HandleImageFile(InputFileChangeEventArgs e)
    {
        byte[] coverBytes;
        
        using (var stream = new MemoryStream())
        {
            await e.File.OpenReadStream().CopyToAsync(stream);
            coverBytes = stream.ToArray();
            _imagePreview = $"data:{e.File.ContentType};base64,{Convert.ToBase64String(coverBytes)}";

            await Mediator.Send(new UpdateBookCoverCommand(BookId, coverBytes));
        }
    
    }
}