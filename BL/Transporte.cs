using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BL
{
    public class Transporte
    {
        public static (bool, string, List<ML.Transporte>, Exception) GetAllLinq()
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var query = (from transporte in context.Transportes
                                 join estatus in context.EstatusTransportes on transporte.IdEstatusTransporte equals estatus.IdEstatus
                                 select new
                                 {
                                     IdTransporte = transporte.IdTransporte,
                                     NumeroPlaca = transporte.NumeroPlaca,
                                     Modelo = transporte.Modelo,
                                     Marca = transporte.Marca,
                                     AnioFabricacion = transporte.AnioFabricacion,
                                     IdEstatus = transporte.IdEstatusTransporte,
                                     Estatus = estatus.Estatus
                                 }
                                ).ToList();

                    ML.Transporte listTransporte = new ML.Transporte();
                    listTransporte.Transportes = new List<ML.Transporte>();
                    if (query.Count > 0)
                    {
                        foreach (var columnTransporte in query)
                        {
                            ML.Transporte rowTransporte = new ML.Transporte();
                            rowTransporte.IdTransporte = columnTransporte.IdTransporte;
                            rowTransporte.NumeroPlaca = columnTransporte.NumeroPlaca;
                            rowTransporte.Modelo = columnTransporte.Modelo;
                            rowTransporte.Marca = columnTransporte.Marca;
                            rowTransporte.AnioFabricacion = columnTransporte.AnioFabricacion;
                            rowTransporte.Estatus = new ML.EstatusTransporte();
                            rowTransporte.Estatus.IdEstatus = columnTransporte.IdEstatus;
                            rowTransporte.Estatus.Estatus = columnTransporte.Estatus;

                            listTransporte.Transportes.Add(rowTransporte);
                        }
                        return (true, null, listTransporte.Transportes, null);
                    }
                    else
                    {
                        return (true, "No hay registros", listTransporte.Transportes, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null, ex);
            }
        }
        public static (bool, string, Exception) Add(ML.Transporte transporte)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "TransporteAdd";
                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parameters = new SqlParameter[5];
                    parameters[0] = new SqlParameter("NumeroPlaca", SqlDbType.VarChar);
                    parameters[0].Value = transporte.NumeroPlaca;
                    parameters[1] = new SqlParameter("Modelo", SqlDbType.VarChar);
                    parameters[1].Value = transporte.Modelo;
                    parameters[2] = new SqlParameter("Marca", SqlDbType.VarChar);
                    parameters[2].Value = transporte.Marca;
                    parameters[3] = new SqlParameter("AnioFabricacion", SqlDbType.Date);
                    parameters[3].Value = transporte.AnioFabricacion;
                    parameters[4] = new SqlParameter("IdEstatus", SqlDbType.Int);
                    parameters[4].Value = transporte.Estatus.IdEstatus;

                    cmd.Parameters.AddRange(parameters);

                    cmd.Connection.Open();

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected > 0)
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
        public static (bool, string, ML.Transporte, Exception) GetById(int idTransporte)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var result = context.TransporteGetById(idTransporte).SingleOrDefault();
                    if (result != null)
                    {
                        ML.Transporte transporte = new ML.Transporte();
                        transporte.IdTransporte = result.IdTransporte;
                        transporte.NumeroPlaca = result.NumeroPlaca;
                        transporte.Modelo = result.Modelo;
                        transporte.Marca = result.Marca;
                        transporte.AnioFabricacion = result.AnioFabricacion;
                        transporte.Estatus = new ML.EstatusTransporte();
                        transporte.Estatus.IdEstatus = result.IdEstatus;
                        transporte.Estatus.Estatus = result.Estatus;

                        return (true, null, transporte, null);
                    }
                    else
                    {
                        return (false, "No se encontro el registro", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
        public static (bool, string, Exception) UpdateEF(ML.Transporte transporte)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowAffected = context.TransporteUpdate(transporte.IdTransporte, transporte.NumeroPlaca, transporte.Modelo,
                                                                    transporte.Marca, transporte.AnioFabricacion, transporte.Estatus.IdEstatus);
                    if (rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "No se actualizo", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, Exception) Delete(int idTransporte)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "DELETE FROM Transporte WHERE IdTransporte = @IdTransporte";
                    SqlCommand cmd = new SqlCommand(query, context);
                    SqlParameter parameter = new SqlParameter("IdTransporte", SqlDbType.Int);
                    parameter.Value = idTransporte;
                    cmd.Parameters.Add(parameter);
                    cmd.Connection.Open();

                    int rowAffected = cmd.ExecuteNonQuery();
                    if(rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "No se ejecuto la consulta", null);
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
