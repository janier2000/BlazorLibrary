using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.Shared.Entities
{
    public class User : IdentityUser
    {
        public DateTime? CreationDate { get; set; }
        public bool? isActive { get; set; }
    }
}
