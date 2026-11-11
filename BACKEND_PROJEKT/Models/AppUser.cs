using Microsoft.AspNetCore.Identity;

namespace BACKEND_PROJEKT.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
