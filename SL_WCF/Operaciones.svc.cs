using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public double Suma(double num1, double num2)
        {
            return num1 + num2;
        }
        public double Resta(double num1, double num2)
        {
            return num1 - num2;
        }
        public double Multiplicacion(double num1, double num2)
        {
            return num1 * num2;
        }
        public double Division(double num1, double num2)
        {
            return num1 / num2;
        }

    }
}
