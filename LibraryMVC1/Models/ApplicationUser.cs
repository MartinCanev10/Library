using Microsoft.AspNetCore.Identity;

namespace LibraryMVC1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string FullName { get;  set; }

    }
}
