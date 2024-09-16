using Microsoft.AspNetCore.Identity;

namespace FondoXYZ.Mdoels{
    public class User : IdentityUser{  // heredamos de identity user
        public string NumberDocument {get; set;}
        public string FullName {get; set; }
        public DateOnly DateBirth {get; set;}
        public DateOnly DateRegistered {get; set;} //Fecha de registro
    }
}