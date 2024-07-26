using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitect.Web.Blazor.AuthExtensions
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 是否為 Admin 的管理人員
        /// </summary>
        [Required]
        public bool IsAdmin { get; set; }
    }
}
