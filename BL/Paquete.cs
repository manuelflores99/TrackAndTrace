using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paquete
    {
        public static (bool Correct, string ErrorTxt, Exception Error) Add(ML.Paquete paquete)
        {
            try
            {
                using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowAffected = context.PaqueteAdd(paquete.InstruccionEntrega, paquete.Peso, paquete.DireccionOrigen, paquete.DireccionEntrega, paquete.FechaEstimadaEntrega, paquete.NumeroGuia, paquete.CodigoQR);
                    if(rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "No se guardo información", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, Exception) Update(ML.Paquete paquete)
        {
            try
            {
                using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowAffected = context.PaqueteUpdate(paquete.IdPaquete, paquete.InstruccionEntrega, paquete.Peso, paquete.DireccionOrigen, paquete.DireccionEntrega, paquete.FechaEstimadaEntrega, paquete.NumeroGuia, paquete.CodigoQR);
                    if(rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "No se realizo la actualización", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, List<ML.Paquete>, Exception) GetAll()
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "SELECT IdPaquete, InstruccionEntrega, Peso, DireccionOrigen, DireccionEntrega, FechaEstimadaEntrega, NumeroGuia, CodigoQR FROM Paquete";
                    SqlCommand cmd = new SqlCommand(query, context);

                    DataTable tablaPaquete = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(tablaPaquete);

                    if(tablaPaquete.Rows.Count > 0)
                    {
                        ML.Paquete paquete = new ML.Paquete();
                        paquete.Paquetes = new List<ML.Paquete>();
                        foreach(DataRow row in tablaPaquete.Rows)
                        {
                            ML.Paquete rowPaquete = new ML.Paquete();
                            rowPaquete.IdPaquete = int.Parse(row[0].ToString());
                            rowPaquete.InstruccionEntrega = row[1].ToString();
                            rowPaquete.Peso = decimal.Parse(row[2].ToString());
                            rowPaquete.DireccionOrigen = row[3].ToString();
                            rowPaquete.DireccionEntrega = row[4].ToString();
                            rowPaquete.FechaEstimadaEntrega = DateTime.Parse(row[5].ToString());
                            rowPaquete.NumeroGuia = row[6].ToString();
                            paquete.Paquetes.Add(rowPaquete);
                        }
                        return (true, null, paquete.Paquetes, null);
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
        public static (bool, string, ML.Paquete, Exception) GetById(int idPaquete)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from paq in context.Paquetes
                                 where paq.IdPaquete == idPaquete
                                 select new
                                 {
                                     IdPaquete = paq.IdPaquete,
                                     InstruccionEntrega = paq.InstruccionEntrega,
                                     Peso = paq.Peso,
                                     DireccionOrigen = paq.DireccionOrigen,
                                     DireccionEntrega = paq.DireccionEntrega,
                                     FechaEstimadaEntrega = paq.FechaEstimadaEntrega,
                                     NumeroGuia = paq.NumeroGuia,
                                     CodigoQR = paq.CodigoQR
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Paquete paquete = new ML.Paquete();
                        paquete.IdPaquete = query.IdPaquete;
                        paquete.InstruccionEntrega = query.InstruccionEntrega;
                        paquete.Peso = query.Peso;
                        paquete.DireccionOrigen = query.DireccionOrigen;
                        paquete.DireccionEntrega = query.DireccionEntrega;
                        paquete.FechaEstimadaEntrega = query.FechaEstimadaEntrega;
                        paquete.NumeroGuia = query.NumeroGuia;
                        paquete.CodigoQR = query.CodigoQR;
                        return (true, null, paquete, null);
                    }
                    else
                    {
                        return (false, "No existe el paquete", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, Exception) Delete(int idPaquete)
        {
            try
            {
                using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from paq in context.Paquetes
                                 where paq.IdPaquete == idPaquete
                                 select paq).First();
                    context.Paquetes.Remove(query);
                    context.SaveChanges();
                    return (true, null, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, List<ML.Paquete>, Exception) CargaMasivaExcel(string connectionString)
        {
            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;

                    OleDbDataAdapter adapater = new OleDbDataAdapter(cmd);

                    DataTable tablePaquete = new DataTable();
                    adapater.Fill(tablePaquete);

                    if (tablePaquete.Rows.Count > 0)
                    {
                        ML.Paquete paquete = new ML.Paquete();
                        paquete.Paquetes = new List<ML.Paquete>();
                        foreach (DataRow row in tablePaquete.Rows)
                        {
                            ML.Paquete column = new ML.Paquete();
                            column.InstruccionEntrega = row[0].ToString();
                            column.Peso = row[1].ToString() != "" ? decimal.Parse(row[1].ToString()) : 0;
                            column.DireccionOrigen = row[2].ToString();
                            column.DireccionEntrega = row[3].ToString();
                            column.FechaEstimadaEntrega = row[4].ToString() != "" ? DateTime.Parse(row[4].ToString()) : new DateTime();
                            column.NumeroGuia = row[5].ToString();

                            paquete.Paquetes.Add(column);
                        }
                        return (true, null, paquete.Paquetes, null);
                    }
                    else return (false, "Error al obtener datos", null, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (ML.ResultExcel, Exception) ExcelValidation(List<ML.Paquete> paquetes)
        {
            try
            {
                ML.ResultExcel error = new ML.ResultExcel();
                error.Errores = new List<ML.ResultExcel>();
                int contador = 2;
                foreach (ML.Paquete paquete in paquetes)
                {
                    ML.ResultExcel catchError = new ML.ResultExcel();
                    catchError.Mensaje = "";
                    catchError.Mensaje += paquete.InstruccionEntrega == "" ? "No contiene instruciones de entrega\r\n" : "";
                    catchError.Mensaje += paquete.Peso == 0 ? "No contiene peso\r\n" : "";
                    catchError.Mensaje += paquete.DireccionOrigen == "" ? "No contiene dirección de origen\r\n" : "";
                    catchError.Mensaje += paquete.DireccionEntrega == "" ? "No contiene dirección de entrega\r\n" : "";
                    catchError.Mensaje += paquete.FechaEstimadaEntrega == new DateTime() ? "No contiene fecha estimada de entrega\r\n" : "";
                    catchError.Mensaje += paquete.NumeroGuia == "" ? "No contiene número de guía\r\n" : "";
                    if(catchError.Mensaje.Length > 0)
                    {
                        catchError.IdFila = contador;
                        error.Errores.Add(catchError);
                    }
                    contador++;
                }
                return (error, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
    }
}
