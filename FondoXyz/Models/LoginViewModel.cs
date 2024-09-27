using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FondoXYZ.Models{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Numero de documento requerido")]
        [Display(Name ="Nro Documento:")]	
        public string DocumentNumber {get; set; }

        [Required(ErrorMessage = "Por favor ingrese la Clave")]
        [DataType(DataType.Password)]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "La contraseña debe tener al menos 4 caracteres nùmericos")]
        [Display(Name = "Clave:" )]
        public string Password {get; set; }
    }
}