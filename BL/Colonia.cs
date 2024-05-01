using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static (bool, string, ML.Colonia, Exception) GetById(int idColonia)
        {
            try
            {
                using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var getColonia = context.ColoniaGetById(idColonia).SingleOrDefault();
                    if(getColonia != null)
                    {
                        ML.Colonia colonia = new ML.Colonia();
                        colonia.IdColonia = getColonia.IdColonia;
                        colonia.Nombre = getColonia.Nombre;
                        colonia.CodigoPostal = getColonia.CodigoPostal;
                        return (true, null, colonia, null);
                    }
                    else
                    {
                        return (false, "Dato no encontrado", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, List<ML.Colonia>, Exception) GetByIdMunicipio(int idMunicipio)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var getColonias = context.ColoniaGetByIdMunicipio(idMunicipio).ToList();
                    if(getColonias.Count > 0)
                    {
                        ML.Colonia colonia = new ML.Colonia();
                        colonia.Colonias = new List<ML.Colonia>();
                        foreach(var columnColonia in getColonias)
                        {
                            ML.Colonia rowMunicipio = new ML.Colonia();
                            rowMunicipio.IdColonia = columnColonia.IdColonia;
                            rowMunicipio.Nombre = columnColonia.Nombre;
                            rowMunicipio.CodigoPostal = columnColonia.CodigoPostal;

                            colonia.Colonias.Add(rowMunicipio);
                        }
                        return (true, null, colonia.Colonias, null);
                    }
                    else
                    {
                        return (false, "No hay datos", null, null);
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
