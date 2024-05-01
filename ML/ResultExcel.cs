using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ResultExcel
    {
        public int IdFila { get; set; }
        public string Mensaje { get; set; }

        public List<ML.ResultExcel> Errores { get; set; }
    }
}
