using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace FondoXYZ.Models{
    public class RegisterViewModel{
        [Required(ErrorMessage = "Por favor ingrese su Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email {get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password {get; set; }
        [Required(ErrorMessage = "Por favor confirme su contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas deben ser iguales")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Las contraseñas deben coincidir")]
        public string ConfirmPassword {get; set; }
        [Required(ErrorMessage = "Nombre completo es requerido")]
        [Display(Name = "Nombre completo")]
        public string FullName {get; set; }
        [Required(ErrorMessage = "Número de documento es requerido")]
        [Display(Name = "Número de documento")]
        public string NumberDocument {get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de nacimiento")]
        public DateOnly BirthDate {get; set; }

    }
}