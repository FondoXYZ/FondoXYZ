using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace FondoXYZ.Mdoels
{
    public class User : IdentityUser
    {  // heredamos de identity user
        [Column("Name")]
        public string Name { get; set; }
        [Column("Email")]
        public string Email {get; set; }

        [Column("DocumentNumber")]
        public string DocumentNumber {get; set; }

        [Column("DateBirth")]
        public DateOnly DateBirth { get; set; }

        [Column("DateRegistered")]
        public DateOnly DateRegistered{ get; set; }

    }
}