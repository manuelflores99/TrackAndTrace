using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static (bool, string, ML.Estado, Exception) GetByIdPais(int idPais)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var getEstados = context.EstadoGetByIdPais(idPais).ToList();

                    if(getEstados.Count > 0)
                    {
                        ML.Estado estados = new ML.Estado();
                        estados.Estados = new List<ML.Estado>();
                        foreach(var columnEstado in getEstados)
                        {
                            ML.Estado rowEstado = new ML.Estado();
                            rowEstado.IdEstado = columnEstado.IdEstado;
                            rowEstado.Nombre = columnEstado.Nombre;
                            estados.Estados.Add(rowEstado);
                        }
                        return (true, null, estados, null);
                    }
                    else
                    {
                        throw new Exception("No hay datos");
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
