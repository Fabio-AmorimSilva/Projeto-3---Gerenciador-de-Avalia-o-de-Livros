namespace BookReviewManagement.Blazor.Components.Pages.Users;

public partial class Logout : ComponentBase
{
    [Inject]
    public ILocalStorageService LocalStorageService { get; set; }
    
    [Inject]
    public TokenAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    protected override async Task OnInitializedAsync()
    { 
        await LocalStorageService.RemoveItemAsync("Bearer");
        await LocalStorageService.RemoveItemAsync("userEmail");
        AuthenticationStateProvider.StateChanged();
        NavigationManager.NavigateTo("/users/login");
    }
}