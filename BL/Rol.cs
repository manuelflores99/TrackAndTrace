using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static (bool, string, ML.Rol, Exception) GetAll()
        {
            try
            {
                using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var getRoles = context.RolGetAll().ToList();

                    if(getRoles.Count > 0)
                    {
                        ML.Rol roles = new ML.Rol();
                        roles.Roles = new List<ML.Rol>();

                        foreach(var rol in getRoles)
                        {
                            ML.Rol rowRol = new ML.Rol();
                            rowRol.IdRol = rol.IdRol;
                            rowRol.Nombre = rol.Nombre;
                            roles.Roles.Add(rowRol);
                        }
                        return (true, null, roles, null);
                    }
                    else
                    {
                        throw new Exception("No se encontraron roles en la base de datos");
                    }
                }
            }
            catch(Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}
