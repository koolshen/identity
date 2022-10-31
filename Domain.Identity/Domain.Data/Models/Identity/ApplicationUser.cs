using Microsoft.AspNetCore.Identity;

namespace Domain.Data.Models.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? SurnameName { get; set; }
    }
}
