using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static (bool, string, ML.Pais, Exception) GetAll()
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var getPaises = context.PaisGetAll().ToList();

                    if(getPaises.Count > 0)
                    {
                        ML.Pais paises = new ML.Pais();
                        paises.Paises = new List<ML.Pais>();
                        foreach (var columnPais in getPaises)
                        {
                            ML.Pais rowPais = new ML.Pais();
                            rowPais.IdPais = columnPais.IdPais;
                            rowPais.Nombre = columnPais.Nombre;
                            paises.Paises.Add(rowPais);
                        }
                        return (true, null, paises, null);
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
