using Blazor8ServerAuthLab2.Models;
//using EasyArchitect.OutsideManaged.AuthExtensions.Models;
using EasyArchitect.Web.Blazor.AuthExtensions;
using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Identity.Data;
using System.Security.Claims;

namespace Blazor8ServerAuthLab2.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly BlazorAuthService _blazorAuth;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthenticationStateProvider(BlazorAuthService blazorAuth, IHttpContextAccessor httpContextAccessor)
        {
            _blazorAuth = blazorAuth;
            _httpContextAccessor = httpContextAccessor;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            Thread.Sleep(1000);

            ClaimsIdentity claimsIdentity = _blazorAuth.AuthIdentityUser.AuthUser.CurrentContextUser.IsAuthenticated ? new ClaimsIdentity(_blazorAuth.AuthIdentityUser.AuthUser.CurrentContextUser.Claims, "CustomAuthType") : new ClaimsIdentity();

            AuthenticationState authenticationState = new AuthenticationState(new ClaimsPrincipal(claimsIdentity));

            return await Task.FromResult(authenticationState);          
        }

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            AuthenticateRequest authRequest = new AuthenticateRequest()
            {
                Username = loginRequest.UserName!,
                Password = loginRequest.Password!
            };
            return await Task.FromResult(_blazorAuth.ProcessLogin(authRequest));
        }
    }
}
