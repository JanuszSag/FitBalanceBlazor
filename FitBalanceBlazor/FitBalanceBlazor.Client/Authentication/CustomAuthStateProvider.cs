using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.ProtectedBrowserStorage;

namespace FitBalanceBlazor
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken = await _localStorage.GetItemAsStringAsync("authToken");
            
            var identity = new ClaimsIdentity();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            if (!string.IsNullOrEmpty(authToken))
            {
                try
                {
                    identity = new ClaimsIdentity(GetClaimsIdentity(authToken));
                    _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", authToken.Replace("\"", ""));
                }
                catch
                {
                    await _localStorage.RemoveItemAsync("authToken");
                    identity = new();
                }
            }
            
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
        
        private ClaimsIdentity GetClaimsIdentity(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            return new ClaimsIdentity(claims,"jwt");
        }
    }
}