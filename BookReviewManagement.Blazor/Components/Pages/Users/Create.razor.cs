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
    public bool IsShow;
    public InputType PasswordInputType { get; set; } = InputType.Password;
    public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

    public async Task OnValidSubmitAsync(EditContext editContext)
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

    public void PasswordTextField()
    {
        if (IsShow)
        {
            IsShow = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInputType = InputType.Password;
        }
        else
        {
            IsShow = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInputType = InputType.Text;
        }
    }
}