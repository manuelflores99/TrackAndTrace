﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        double Suma(double num1, double num2);
        [OperationContract]
        double Resta(double num1, double num2);
        [OperationContract]
        double Multiplicacion(double num1, double num2);
        [OperationContract]
        double Division(double num1, double num2);
    }
}
