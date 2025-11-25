using Microsoft.AspNetCore.Identity;

namespace CarBackend.Core.Models
{
    public class User : IdentityUser
    {
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
    }
}