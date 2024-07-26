using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitect.Web.Blazor.AuthExtensions
{
    /// <summary>
    /// 當前登入使用者實體定義
    /// </summary>
    public class CurrentUser : AuthenticateRequest
    {
        public bool IsAuthenticated { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
