using Microsoft.AspNetCore.Identity;

namespace Clinic.Domain.Entities.Auth
{
    public class User : IdentityUser
    {
        public string Firsname { get; set; }
        public string Lastname { get; set; }
        public string Role {  get; set; }
    }
}
