using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repartidor
    {
        public static (bool, string, List<ML.Repartidor>, Exception) GetAll()
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "RepartidorGetAll";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable tablaRepartidor = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(tablaRepartidor);

                    if(tablaRepartidor.Rows.Count > 0)
                    {
                        ML.Repartidor repartidor = new ML.Repartidor();
                        repartidor.Repartidores = new List<ML.Repartidor>();
                        foreach(DataRow row in tablaRepartidor.Rows)
                        {
                            ML.Repartidor columnRepartidor = new ML.Repartidor();
                            columnRepartidor.IdRepartidor = int.Parse(row[0].ToString());
                            columnRepartidor.Nombre = row[1].ToString();
                            columnRepartidor.ApellidoPaterno = row[2].ToString();
                            columnRepartidor.ApellidoMaterno = row[3].ToString();
                            repartidor.Repartidores.Add(columnRepartidor);
                        }
                        return (true, null, repartidor.Repartidores, null);
                    }
                    else
                    {
                        return (true, "No hay datos", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, ML.Repartidor, Exception) GetById(int idRepartidor)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from repartidor in context.Repartidors
                                 where repartidor.IdRepartidor == idRepartidor
                                 select new
                                 {
                                     IdRepartidor = repartidor.IdRepartidor,
                                     Nombre = repartidor.Nombre,
                                     ApellidoPaterno = repartidor.ApellidoPaterno,
                                     ApellidoMaterno = repartidor.ApellidoMaterno
                                 }).SingleOrDefault();
                    if(query != null)
                    {
                        ML.Repartidor repartidor = new ML.Repartidor();
                        repartidor.IdRepartidor = query.IdRepartidor;
                        repartidor.Nombre = query.Nombre;
                        repartidor.ApellidoPaterno = query.ApellidoPaterno;
                        repartidor.ApellidoMaterno = query.ApellidoMaterno;
                        return (true, null, repartidor, null);
                    }
                    else
                    {
                        return (false, "Error al consultar información", null, null);
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
