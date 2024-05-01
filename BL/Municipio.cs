using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static (bool, string, ML.Municipio, Exception) GetByIdEstado(int idEstado)
        {
            try
            {
                using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities()){
                    var getMunicipios = context.MunicipioGetByIdEstado(idEstado).ToList();
                    if(getMunicipios.Count > 0)
                    {
                        ML.Municipio municipios = new ML.Municipio();
                        municipios.Municipios = new List<ML.Municipio>();
                        foreach(var columnMunicipios in getMunicipios)
                        {
                            ML.Municipio rowMunicipio = new ML.Municipio();
                            rowMunicipio.IdMunicipio = columnMunicipios.IdMunicipio;
                            rowMunicipio.Nombre = columnMunicipios.Nombre;
                            municipios.Municipios.Add(rowMunicipio);
                        }
                        return (true, null, municipios, null);
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
