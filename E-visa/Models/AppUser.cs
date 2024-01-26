using Microsoft.AspNetCore.Identity;

namespace E_Visa.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Address { get; set; }

        public List<EvisaForm>? EvisaForm { get; set; }
    }
}
