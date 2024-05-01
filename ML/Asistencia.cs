using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }
        [Display(Name = "Asunto")]
        [Required(ErrorMessage = "Indique el asunto del mensaje")]
        public string Titulo { get; set; }
        [Display(Name = "Mensaje")]
        [Required(ErrorMessage = "Especifique el apoyo que requiere")]
        public string Mensaje { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Es necesario que proporcione su correo electrónico")]
        public string Email { get; set; }
        public DateTime FechaUp { get; set; }
        public DateTime FechaDown { get; set; }

        public string NumeroSeguimiento { get; set; } = DateTime.Now.ToString("yyyyMMddhhmmss");

        public EstatusAsistencia Estatus { get; set; }

        public Asistencia Asistencias { get; set; }
    }
}
