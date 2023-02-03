using System.ComponentModel.DataAnnotations;

namespace MVC2.ViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}
