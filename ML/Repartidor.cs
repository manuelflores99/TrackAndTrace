using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public partial class Repartidor
    {
        public int IdRepartidor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public List<ML.Repartidor> Repartidores { get; set; }
    }
    public partial class Repartidor
    {
        public int? Asignaciones { get; set; }
    }
}
