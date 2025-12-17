using Microsoft.AspNetCore.Identity;

namespace CarBackend.Core.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}