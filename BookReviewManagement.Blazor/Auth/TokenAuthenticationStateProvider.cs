namespace BookReviewManagement.Blazor.Auth;

public class TokenAuthenticationStateProvider(
    HttpClient httpClient, 
    ILocalStorageService localStorageService
) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await GetTokenAsync();
        var anonymousState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        if (string.IsNullOrWhiteSpace(token))
            return anonymousState;
        
        var claims = ParseClaimsFromJwt(token);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var identity = new ClaimsIdentity(claims, "jwt");
        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);
        
        NotifyAuthenticationStateChanged(task: Task.FromResult(state));
        
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
    
    public void StateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    
    private async Task<string> GetTokenAsync() => await localStorageService.GetItemAsync<string>("Bearer") ?? string.Empty;
    
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = Convert.FromBase64String(payload.PadRight(payload.Length + payload.Length % 4, '='));
        var claims = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return claims.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }
}