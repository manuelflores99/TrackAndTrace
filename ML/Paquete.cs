using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Paquete
    {
        public int IdPaquete { get; set; }
        [Display(Name = "Instruccion de entrega")]
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$", ErrorMessage = "Solo se permiten letras")]
        public string InstruccionEntrega { get; set; }
        [Display(Name = "Peso del paquete")]
        [Required]
        [RegularExpression(@"^[0-9]+([.])?([0-9]+)?$", ErrorMessage = "Solo se permiten números")]
        public decimal Peso { get; set; }
        [Display(Name = "Dirección de origen")]
        [Required(ErrorMessage = "La dirección de origen es requerida")]
        public string DireccionOrigen { get; set; }
        [Display(Name = "Dirección de entrega")]
        [Required(ErrorMessage = "La dirección de entrega es requerida")]
        public string DireccionEntrega { get; set; }
        [Display(Name = "Fecha estimada de entrega")]
        [Required]
        public DateTime FechaEstimadaEntrega { get; set; }
        [Display(Name = "Número de guía")]
        [Required]
        public string NumeroGuia { get; set; }
        [Display(Name = "Código QR")]
        public byte[] CodigoQR { get; set; }
        public ML.Repartidor Repartidor { get; set; }

        public List<ML.Paquete> Paquetes { get; set; }
    }
}
