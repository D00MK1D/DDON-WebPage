using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace DDON_WebPage.Components.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private ClaimsPrincipal _currentUser = null!;

        public void MarkUserAsAuthenticated(string username, int userId)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("UserId", userId.ToString())
            }, "apiauth");

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }

        public void MarkUserAsLoggedOut()
        {
            _currentUser = _anonymous;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(
                _currentUser != null ? new AuthenticationState(_currentUser) : new AuthenticationState(_anonymous)
            );
        }
    }
}