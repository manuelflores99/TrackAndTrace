using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$", ErrorMessage = "Ha ingresado caracteres no permitidos, verifícalo")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$", ErrorMessage = "Ha ingresado caracteres no permitidos, verifícalo")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$", ErrorMessage = "Ha ingresado caracteres no permitidos, verifícalo")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Correo electrónico no válida, verifícalo")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@@#$%^&*])[a-zA-Z0-9!@@#$%^&*]{8,8}$", ErrorMessage = "Contraseña no es válido, verifícalo")]
        public string Password { get; set; }
        public string Sexo { get; set; }
        [Display(Name = "Teléfono")]
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Teléfono no válido, verifícalo")]
        public string Telefono { get; set; }
        [Display(Name = "Celular")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Celular no válido, verifícalo")]
        public string Celular { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public string Imagen { get; set; }
        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }

        public bool Estatus { get; set; }

        public List<object> Usuarios { get; set; }
    }
}
