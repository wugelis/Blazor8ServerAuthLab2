//using EasyArchitect.OutsideManaged.AuthExtensions.Models;
//using EasyArchitect.PageModel.AuthExtensions;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
using EasyArchitect.PageModel.AuthExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitect.Web.Blazor.AuthExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BlazorAuthService
    {
        public AuthIdentity AuthIdentityUser { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public BlazorAuthService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            AuthIdentityUser = new AuthIdentity(_httpContextAccessor);
        }
        /// <summary>
        /// 處理登入與產生 Token 作業（當外部使用者存在時）
        /// </summary>
        /// <param name="account"></param>
        public bool ProcessLogin(AuthenticateRequest? account)
        {
            bool result = true;

            List<Claim> claims = GetAuthIdentity(account);

            try
            {
                AuthIdentityUser.AuthUser.CurrentContextUser = new CurrentUser()
                {
                    Username = account!.Username,
                    IsAuthenticated = true,
                    Claims = claims
                };

                AppendNewCookie(account);

            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public static List<Claim> GetAuthIdentity(AuthenticateRequest account)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, account!.Username),
                new Claim(ClaimTypes.Role, "Administrator")
            };
        }

        private void AppendNewCookie(AuthenticateRequest account)
        {
            int timeoutExpires = _configuration.GetSection("AppSettings").GetValue<int>("TimeoutMinutes");
            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMinutes(timeoutExpires),
                HttpOnly = true
            };

            NewCookie gqsCookie = new NewCookie(EasyArchitectCore.Core.UserInfo.LOGIN_USER_INFO);
            gqsCookie.Values.Add("Username", account.Username);

            string jsonString = NewCookie.GetJsonByNewCookie(gqsCookie);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(EasyArchitectCore.Core.UserInfo.LOGIN_USER_INFO, jsonString, cookieOptions);
        }

        /// <summary>
        /// 進行登出作業
        /// </summary>
        /// <returns></returns>
        //[AllowAnonymous]
        public void LogoutProcess()
        {
            //_httpContextAccessor.HttpContext.SignOutAsync().GetAwaiter();

            //_httpContextAccessor.HttpContext.Response.Cookies.Delete(EasyArchitectCore.Core.UserInfo.LOGIN_USER_INFO);

            _httpContextAccessor.HttpContext.Response.Redirect(_configuration.GetSection("AppSettings").GetValue<string>("LoginPage"));
        }

        //public static NewCookie GetCurrentContextCookie()
        //{
            
        //}
    }

    public class AuthIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthIdentity(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            AuthUser = new User(_httpContextAccessor);
        }

        public User AuthUser { get; set; }
        public class User
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public User(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
                string Username = string.Empty;
                bool loginState = false;

                _httpContextAccessor!.HttpContext!.Request.Cookies.TryGetValue(EasyArchitectCore.Core.UserInfo.LOGIN_USER_INFO, out string? cookieValue);
                if(cookieValue != null)
                {
                    NewCookie authCookie = NewCookie.GetNewCookieByString(cookieValue, EasyArchitectCore.Core.UserInfo.LOGIN_USER_INFO);
                    loginState = authCookie.Values.CookieValue.Where(c => c.Key == "Username").Count() > 0;
                    if(loginState)
                    {
                        Username = authCookie.Values["Username"];
                    }
                }
                
                CurrentContextUser = new CurrentUser()
                {
                    IsAuthenticated = loginState,
                    Claims = BlazorAuthService.GetAuthIdentity(new AuthenticateRequest() { Username = Username })
                };
            }
            public CurrentUser CurrentContextUser { get; set; }
        }
    }
}
