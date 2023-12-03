using Microsoft.AspNetCore.Identity;

namespace LingWo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Location { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
    }
}