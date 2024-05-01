using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstatusTransporte
    {
        public static (bool, string, List<ML.EstatusTransporte>, Exception) GetAll()
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from estatus in context.EstatusTransportes
                                 select new
                                 {
                                     IdEstatus = estatus.IdEstatus,
                                     Estatus = estatus.Estatus
                                 }
                                ).ToList();
                    ML.EstatusTransporte estatusTransporte = new ML.EstatusTransporte();
                    estatusTransporte.EstatusTransportes = new List<ML.EstatusTransporte>();
                    if(query.Count > 0)
                    {
                        foreach (var columnEstatus in query)
                        {
                            ML.EstatusTransporte rowEstatus = new ML.EstatusTransporte();
                            rowEstatus.IdEstatus = columnEstatus.IdEstatus;
                            rowEstatus.Estatus = columnEstatus.Estatus;

                            estatusTransporte.EstatusTransportes.Add(rowEstatus);
                        }

                        return (true, null, estatusTransporte.EstatusTransportes, null);
                    }
                    else
                    {
                        return (true, "No hay datos", estatusTransporte.EstatusTransportes, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}
