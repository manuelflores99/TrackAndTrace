using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class EstatusAsistencia
    {
        public int IdEstatus { get; set; } = 1;
        public string Nombre { get; set; }

        public EstatusAsistencia Estados { get; set; }
    }
}
