using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstatusAsistencia
    {
        public static (bool Success, string MessageError, List<ML.EstatusAsistencia> Estatus, Exception Error) GetAll()
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "SELECT IdEstatus, Nombre FROM EstatusAsistencia";

                    SqlCommand cmd = new SqlCommand(query, context);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    if(table.Rows.Count > 0)
                    {
                        List<ML.EstatusAsistencia> estados = new List<ML.EstatusAsistencia>();

                        foreach (DataRow row in table.Rows)
                        {
                            ML.EstatusAsistencia estado = new ML.EstatusAsistencia
                            {
                                IdEstatus = int.Parse(row[0].ToString()),
                                Nombre = row[1].ToString()
                            };
                            estados.Add(estado);
                        }

                        return (true, null, estados, null);
                    }
                    else
                    {
                        return (false, "No hay estados", null, null);
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
