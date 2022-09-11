using Microsoft.AspNetCore.Identity;

namespace MiniProjectBackendAPI.Authentication
{
    public class AuthenticateEmployer :IdentityUser
    {
        public string Username { get; set; }

        public string CompanyName { get; set; }

        public string Details { get; set; }

        public string Password { get; set; }

        public string AlternatePhoneNumber { get; set; }

        public string Category { get; set; }
    }
}
