using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Paquete" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Paquete.svc or Paquete.svc.cs at the Solution Explorer and start debugging.
    public class Paquete : IPaquete
    {
        public (bool, string, Exception) Add(ML.Paquete paquete)
        {
            var result = BL.Paquete.Add(paquete);
            return (result.Correct, result.ErrorTxt, result.Error);
        }

        public (bool, string, Exception) Delete(int idPaquete)
        {
            var result = BL.Paquete.Delete(idPaquete);
            return (result.Item1, result.Item2, result.Item3);
        }

        public (bool, string, List<ML.Paquete>, Exception) GetAll()
        {
            var result = BL.Paquete.GetAll();
            return (result.Item1, result.Item2, result.Item3, result.Item4);
        }

        public (bool, string, ML.Paquete, Exception) GetById(int idPaquete)
        {
            var result = BL.Paquete.GetById(idPaquete);
            return (result.Item1, result.Item2, result.Item3, result.Item4);
        }

        public (bool, string, Exception) Update(ML.Paquete paquete)
        {
            var result = BL.Paquete.Update(paquete);
            return (result.Item1, result.Item2, result.Item3);
        }
    }
}
