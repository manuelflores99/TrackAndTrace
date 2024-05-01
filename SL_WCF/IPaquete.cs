using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaquete" in both code and config file together.
    [ServiceContract]
    public interface IPaquete
    {
        [OperationContract]
        (bool, string, Exception) Add(ML.Paquete paquete);
        [OperationContract]
        (bool, string, List<ML.Paquete>, Exception) GetAll();
        [OperationContract]
        (bool, string, ML.Paquete, Exception) GetById(int idPaquete);
        [OperationContract]
        (bool, string, Exception) Update(ML.Paquete paquete);
        [OperationContract]
        (bool, string, Exception) Delete(int idPaquete);
    }
}
