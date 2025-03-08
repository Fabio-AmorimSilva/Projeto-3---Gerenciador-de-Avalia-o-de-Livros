namespace BookReviewManagement.Blazor.Components.Pages.Users;

public partial class Create : ComponentBase
{
    [Inject]
    private IMediator Mediator { get; set; }
    [Inject]
    private NavigationManager Navigation { get; set; }
    [Inject]
    private ISnackbar Snackbar { get; set; }

    [Inject]
    private IDialogService DialogService { get; set; }
    
    public UserInputModel UserInputModel { get; set; } = new();

    public async void OnValidSubmitAsync(EditContext editContext)
    {
        if (editContext.Model is UserInputModel model)
        {
            var command = new CreateUserCommand
            (
                Name: model.Name,
                Email: model.Email,
                Password: model.Password
            );
            
            var result = await Mediator.Send(command);

            if (!result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Error);
                return;
            }

            Snackbar.Add("User was successfully created!!", Severity.Success);
            Navigation.NavigateTo("/users");
        }
        else
        {
            Snackbar.Add("An Error has occurred", Severity.Error);
        }
    }
}