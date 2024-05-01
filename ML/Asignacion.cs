using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Asignacion
    {
        public ML.Repartidor Repartidor { get; set; }
        public ML.Paquete Paquete { get; set; }
        public int TotalPaquete { get; set; } = 1;
        public List<ML.Asignacion> Asignaciones { get; set; }
    }
}
