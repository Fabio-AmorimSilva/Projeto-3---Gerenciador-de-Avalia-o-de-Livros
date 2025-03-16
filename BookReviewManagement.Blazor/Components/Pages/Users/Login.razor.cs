namespace BookReviewManagement.Blazor.Components.Pages.Users;

public partial class Login : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }
    
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ILocalStorageService LocalStorage { get; set; }
    
    private LoginInputModel LoginInputModel { get; set; } = new();
    
    [Inject]
    public TokenAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    
    public bool IsShow;
    public InputType PasswordInputType { get; set; } = InputType.Password;
    public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
    
    private async Task OnValidSubmitAsync(EditContext editContext)
    {
        if (editContext.Model is LoginInputModel model)
        {
            var command = new LoginCommand(
                Email: model.Email,
                Password: model.Password
            );
            
            var response = await Mediator.Send(command);

            if (!response.IsSuccess)
            {
                Snackbar.Add($"{response.Message}", Severity.Error);
            }
            else
            {
                await LocalStorage.SetItemAsync("Bearer", response.Data);
                await LocalStorage.SetItemAsync("userEmail", model.Email);
                AuthenticationStateProvider.StateChanged();
            }
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