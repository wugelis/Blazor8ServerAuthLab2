using System.ComponentModel.DataAnnotations;

namespace Blazor8ServerAuthLab2.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "使用者登入名稱：")]
        public string? UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "密碼：")]
        public string? Password { get; set; }
    }
}
