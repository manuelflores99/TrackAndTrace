using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Asistencia
    {
        public static (bool Success, string MessageError, Exception Error) Add(ML.Asistencia asistencia)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "INSERT INTO Asistencia (Email, Titulo, Mensaje, IdEstatus, NumeroSeguimiento) VALUES(@Email, @Titulo, @Mensaje, @IdEstatus, @NumeroSeguimiento)";

                    SqlCommand cmd = new SqlCommand(query, context);

                    SqlParameter[] parameters = new SqlParameter[5];
                    parameters[0] = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                    parameters[0].Value = asistencia.Email;

                    parameters[1] = new SqlParameter("Titulo", System.Data.SqlDbType.VarChar);
                    parameters[1].Value = asistencia.Titulo;

                    parameters[2] = new SqlParameter("Mensaje", System.Data.SqlDbType.NVarChar);
                    parameters[2].Value = asistencia.Mensaje;

                    parameters[3] = new SqlParameter("IdEstatus", System.Data.SqlDbType.Int);
                    parameters[3].Value = asistencia.Estatus.IdEstatus;
                    parameters[4] = new SqlParameter("NumeroSeguimiento", System.Data.SqlDbType.VarChar);
                    parameters[4].Value = asistencia.NumeroSeguimiento;

                    cmd.Parameters.AddRange(parameters);

                    cmd.Connection.Open();

                    int rowAffected = cmd.ExecuteNonQuery();

                    if(rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "No se pudo realizar el registro", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
    }
}
