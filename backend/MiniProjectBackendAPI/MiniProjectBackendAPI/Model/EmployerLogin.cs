using System.ComponentModel.DataAnnotations;

namespace MiniProjectBackendAPI.Model
{
    public class EmployerLogin
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
