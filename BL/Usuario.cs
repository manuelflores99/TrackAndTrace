using DL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //public static bool Add(ML.Usuario usuario)
        //{
        //    try
        //    {
        //        SqlConnection context = new SqlConnection(DL.Conexion.Get());
        //        //string query = "INSERT INTO [Usuario] ([Nombre], [ApellidoPaterno], [ApellidoMaterno]) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno)";
        //        //or
        //        string query = "UsuarioAdd";
        //        SqlCommand cmd = new SqlCommand(query, context);
        //        cmd.CommandType = CommandType.StoredProcedure; //Solo si es procedimiento almacenado

        //        SqlParameter[] parameters = new SqlParameter[3];
        //        parameters[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
        //        parameters[0].Value = usuario.Nombre;
        //        parameters[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
        //        parameters[1].Value = usuario.ApellidoPaterno;
        //        parameters[2] = new SqlParameter("ApellidoMAterno", System.Data.SqlDbType.VarChar);
        //        parameters[2].Value = usuario.ApellidoMaterno;

        //        cmd.Parameters.AddRange(parameters);

        //        cmd.Connection.Open();

        //        int rowAffected = cmd.ExecuteNonQuery();
        //        cmd.Connection.Close();

        //        if (rowAffected > 0) { return true; }
        //        else { return false; }
        //    }
        //    catch (Exception ex) { return false; }
        //}
        //public static bool Update(ML.Usuario usuario)
        //{
        //    try
        //    {
        //        SqlConnection context = new SqlConnection(DL.Conexion.Get());
        //        //string query = "UPDATE [Usuario] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno "
        //        //                    + "WHERE [IdUsuario] = @IdUsuario";
        //        //or
        //        string query = "UsuarioUpdate";
        //        SqlCommand cmd = new SqlCommand(query, context);

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter[] parameters = new SqlParameter[4];
        //        parameters[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
        //        parameters[0].Value = usuario.Nombre;
        //        parameters[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
        //        parameters[1].Value = usuario.ApellidoPaterno;
        //        parameters[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
        //        parameters[2].Value = usuario.ApellidoMaterno;
        //        parameters[3] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
        //        parameters[3].Value = usuario.IdUsuario;

        //        cmd.Parameters.AddRange(parameters);

        //        cmd.Connection.Open();
        //        int rowAffected = cmd.ExecuteNonQuery();
        //        cmd.Connection.Close();
        //        if (rowAffected > 0) { return true; }
        //        else { return false; }
        //    }
        //    catch (Exception ex) { return false; }
        //}
        //public static bool Delete(ML.Usuario usuario)
        //{
        //    try
        //    {
        //        SqlConnection context = new SqlConnection(DL.Conexion.Get());
        //        //string query = "DELETE FROM [Usuario] WHERE [IdUsuario] = @IdUsuario";
        //        //or
        //        string query = "UsuarioDelete";
        //        SqlCommand cmd = new SqlCommand(query, context);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter parameter = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
        //        parameter.Value = usuario.IdUsuario;

        //        cmd.Parameters.Add(parameter);

        //        cmd.Connection.Open();
        //        int rowAffected = cmd.ExecuteNonQuery();
        //        cmd.Connection.Close();

        //        if (rowAffected > 0) { return true; }
        //        else { return false; }
        //    }
        //    catch(Exception ex) { return false; }
        //}
        //public static ML.Usuario GetAll()
        //{
        //    ML.Usuario usuarios = new ML.Usuario();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            //string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno FROM Usuario";
        //            //or
        //            string query = "UsuarioGetAll";

        //            SqlCommand cmd = new SqlCommand(query, context);

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            DataTable tableUsuario = new DataTable();

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            adapter.Fill(tableUsuario);

        //            if (tableUsuario.Rows.Count > 0)
        //            {
        //                usuarios.Usuarios = new List<object>();

        //                foreach (DataRow row in tableUsuario.Rows)
        //                {
        //                    ML.Usuario objectUsuario = new ML.Usuario();
        //                    objectUsuario.IdUsuario = int.Parse(row[0].ToString());
        //                    objectUsuario.UserName = row[1].ToString();
        //                    objectUsuario.Nombre = row[2].ToString();
        //                    objectUsuario.ApellidoPaterno = row[3].ToString();
        //                    objectUsuario.ApellidoMaterno = row[4].ToString();
        //                    objectUsuario.Email = row[5].ToString();
        //                    objectUsuario.Password = row[6].ToString();
        //                    objectUsuario.Sexo =row[7].ToString();
        //                    objectUsuario.Telefono = row[8].ToString();
        //                    objectUsuario.Celular = row[9].ToString();
        //                    usuarios.Usuarios.Add(objectUsuario);
        //                }
        //            } else
        //            {
        //                //Pendiente
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return usuarios;

        //}
        //public static ML.Usuario GetById(int idUsuario)
        //{
        //    ML.Usuario usuario = new ML.Usuario();

        //    try
        //    {
        //        using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            //string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno FROM Usuario WHERE IdUsuario = @IdUsuario";
        //            //or
        //            string query = "UsuarioGetById";
        //            SqlCommand cmd = new SqlCommand(query, context);

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter parameter = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
        //            parameter.Value = idUsuario;

        //            cmd.Parameters.Add(parameter);

        //            DataTable tableUsuario = new DataTable();

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            adapter.Fill(tableUsuario);

        //            if( tableUsuario.Rows.Count > 0 )
        //            {
        //                usuario.IdUsuario = int.Parse(tableUsuario.Rows[0][0].ToString());
        //                usuario.Nombre = tableUsuario.Rows[0][1].ToString();
        //                usuario.ApellidoPaterno = tableUsuario.Rows[0][2].ToString();
        //                usuario.ApellidoMaterno = tableUsuario.Rows[0][3].ToString();
        //            } else
        //            {
        //                //Pendiente
        //            }
        //        }
        //    } catch (Exception ex)
        //    {

        //    }
        //    return usuario;
        //}
        //public static (bool, string, ML.Usuario, Exception) GetAllLinq()
        //{
        //    ML.Usuario usuarios = new ML.Usuario();
        //    try
        //    {
        //        using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities()){

        //            var query = (from usuario in context.Usuarios
        //                         select new {   IdUsuario = usuario.IdUsuario,
        //                                        UserName = usuario.UserName,
        //                                        Nombre = usuario.Nombre,
        //                                        ApellidoPaterno = usuario.ApellidoPaterno,
        //                                        ApellidoMaterno = usuario.ApellidoMaterno,
        //                                        Email = usuario.Email,
        //                                        FechaNacimiento = usuario.FechaNacimiento,
        //                                        Sexo = usuario.Sexo,
        //                                        Telefono = usuario.Telefono
        //                                     }
        //                                     ).ToList();

        //            if ( query != null )
        //            {
        //                usuarios.Usuarios = new List<object>();
        //                foreach ( var usuario in query)
        //                {
        //                    ML.Usuario objUsuario = new ML.Usuario();
        //                    objUsuario.IdUsuario = usuario.IdUsuario;
        //                    objUsuario.UserName = usuario.UserName;
        //                    objUsuario.Nombre = usuario.Nombre;
        //                    objUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
        //                    objUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
        //                    objUsuario.Email = usuario.Email;
        //                    objUsuario.FechaNacimiento = usuario.FechaNacimiento;
        //                    objUsuario.Sexo = usuario.Sexo;
        //                    objUsuario.Telefono = usuario.Telefono;
        //                    usuarios.Usuarios.Add( objUsuario );
        //                }
        //                return (true, null, usuarios, null);
        //            }
        //            else
        //            {
        //                throw new Exception("NO DATA");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, null, ex);
        //    }
        //}
        //public static (bool, string, ML.Usuario, Exception) GetByIdLinq(int idUsuario)
        //{
        //    ML.Usuario usuarioGet = new ML.Usuario();
        //    try
        //    {
        //        using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
        //        {
        //            var query = (from usuario in context.Usuarios
        //                         where usuario.IdUsuario == idUsuario
        //                         select new {
        //                                    IdUsuario = usuario.IdUsuario,
        //                                    UserName = usuario.UserName,
        //                                    Nombre = usuario.Nombre,
        //                                    ApellidoPaterno = usuario.ApellidoPaterno,
        //                                    ApellidoMaterno = usuario.ApellidoMaterno,
        //                                    Email = usuario.Email,
        //                                    FechaNacimiento = usuario.FechaNacimiento,
        //                                    Sexo = usuario.Sexo,
        //                                    Telefono = usuario.Telefono
        //                            }
        //                         ).SingleOrDefault();
        //            if( query != null )
        //            {
        //                usuarioGet.IdUsuario = query.IdUsuario;
        //                usuarioGet.UserName = query.UserName;
        //                usuarioGet.Nombre = query.Nombre;
        //                usuarioGet.ApellidoPaterno = query.ApellidoPaterno;
        //                usuarioGet.ApellidoMaterno = query.ApellidoMaterno;
        //                usuarioGet.Email = query.Email;
        //                usuarioGet.FechaNacimiento = query.FechaNacimiento;
        //                usuarioGet.Sexo = query.Sexo;
        //                usuarioGet.Telefono = query.Telefono;
        //                return (true, null, usuarioGet, null);
        //            }
        //            else
        //            {
        //                throw new Exception("NO DATA");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, null, ex);
        //    }
        //}
        //public static (bool, string, Exception) AddLinq(ML.Usuario usuario)
        //{
        //    try
        //    {
        //        using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
        //        {
        //            DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

        //            usuarioDL.UserName = usuario.UserName;
        //            usuarioDL.Nombre = usuario.Nombre;
        //            usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
        //            usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
        //            usuarioDL.Email = usuario.Email;
        //            usuarioDL.Password = usuario.Password;
        //            usuarioDL.FechaNacimiento = usuario.FechaNacimiento;
        //            usuarioDL.Sexo = usuario.Sexo;
        //            usuarioDL.Telefono = usuario.Telefono;

        //            context.Usuarios.Add(usuarioDL);
        //            int rowAffected = context.SaveChanges();
        //            if (rowAffected > 0)
        //            {
        //                return (true, null, null);
        //            }
        //            else
        //            {
        //                throw new Exception("NO INSERT");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, ex);
        //    }
        //}
        //public static (bool, string, Exception) UpdateLinq(ML.Usuario usuario)
        //{
        //    try
        //    {
        //        using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
        //        {
        //            var query = (from usuarioUpdate in context.Usuarios
        //                         where usuarioUpdate.IdUsuario == usuario.IdUsuario
        //                         select usuarioUpdate).SingleOrDefault();

        //            if(query != null)
        //            {
        //                query.UserName = usuario.UserName;
        //                query.Nombre = usuario.Nombre;
        //                query.ApellidoPaterno = usuario.ApellidoPaterno;
        //                query.ApellidoMaterno = usuario.ApellidoMaterno;
        //                query.Email = usuario.Email;
        //                query.Password = usuario.Password;
        //                query.FechaNacimiento = usuario.FechaNacimiento;
        //                query.Sexo = usuario.Sexo;
        //                query.Telefono = usuario.Telefono;

        //                int rowAffected = context.SaveChanges();

        //                if (rowAffected > 0)
        //                {
        //                    return (true, null, null);
        //                }
        //                else
        //                {
        //                    throw new Exception("DATA NO UPDATE");
        //                }
        //            } 
        //            else
        //            {
        //                throw new Exception("NO QUERY EXECUTED");
        //            }
        //        }
        //    } catch (Exception ex)
        //    {
        //        return (false, ex.Message, ex);
        //    }
        //}
        //public static (bool, string, Exception) DeleteLinq(int idUsuario)
        //{
        //    try
        //    {
        //        using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
        //        {
        //            var query = (from usuario in context.Usuarios
        //                         where usuario.IdUsuario == idUsuario
        //                         select usuario
        //                         ).SingleOrDefault();
        //            if( query != null )
        //            {
        //                context.Usuarios.Remove( query );
        //                int rowAffected = context.SaveChanges();
        //                if( rowAffected > 0 )
        //                {
        //                    return (true, null, null);
        //                }
        //                else
        //                {
        //                    throw new Exception("DATA NO REMOVE");
        //                }
        //            }
        //            else
        //            {
        //                throw new Exception("NO DATA FOUND");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, ex);
        //    }
        //}
        public static (bool, string, Exception) AddEF(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Imagen, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    if (rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        throw new Exception("It was not able to be added to the database");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, Exception) UpdateEF(ML.Usuario usuario)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno,
                                                                usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono,
                                                                    usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Imagen, usuario.Rol.IdRol,
                                                                    usuario.Direccion.IdDireccion, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, 
                                                                    usuario.Direccion.NumeroInterior, usuario.Direccion.Colonia.IdColonia);
                    if (rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        throw new Exception("It cannot update the information (Element no found)");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, Exception) DeleteEF(int idUsuario, int idDireccion)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioDelete(idUsuario, idDireccion);
                    if (rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        throw new Exception("No elements found");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetAllEF(ML.Usuario usuarioBusquedad)
        {
            ML.Usuario usuarioGet = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var usuarios = context.UsuarioGetAll(usuarioBusquedad.Nombre, usuarioBusquedad.ApellidoPaterno, usuarioBusquedad.ApellidoMaterno).ToList();

                    if (usuarios.Count > 0)
                    {
                        usuarioGet.Usuarios = new List<object>();

                        foreach (var usuario in usuarios)
                        {
                            ML.Usuario rowUsuario = new ML.Usuario();
                            rowUsuario.IdUsuario = usuario.IdUsuario;
                            rowUsuario.UserName = usuario.UserName;
                            rowUsuario.Nombre = usuario.Nombre;
                            rowUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                            rowUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                            rowUsuario.Email = usuario.Email;
                            rowUsuario.Password = usuario.Password;
                            rowUsuario.FechaNacimiento = usuario.FechaNacimiento;
                            rowUsuario.Sexo = usuario.Sexo;
                            rowUsuario.Imagen = usuario.Imagen;
                            rowUsuario.Telefono = usuario.Telefono;
                            rowUsuario.Celular = usuario.Celular;
                            rowUsuario.CURP = usuario.CURP;
                            rowUsuario.Estatus = usuario.Estatus;
                            rowUsuario.Rol = new ML.Rol();
                            rowUsuario.Rol.IdRol = usuario.IdRol;
                            rowUsuario.Rol.Nombre = usuario.NombreRol;
                            rowUsuario.Direccion = new ML.Direccion();
                            rowUsuario.Direccion.IdDireccion = usuario.IdDireccion;
                            rowUsuario.Direccion.Calle = usuario.Calle;
                            rowUsuario.Direccion.NumeroInterior = usuario.NumeroInterior;
                            rowUsuario.Direccion.NumeroExterior = usuario.NumeroExterior;
                            rowUsuario.Direccion.Colonia = new ML.Colonia();
                            rowUsuario.Direccion.Colonia.IdColonia = usuario.IdColonia;
                            rowUsuario.Direccion.Colonia.Nombre = usuario.NombreColonia;
                            rowUsuario.Direccion.Colonia.CodigoPostal = usuario.CodigoPostal;
                            rowUsuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            rowUsuario.Direccion.Colonia.Municipio.IdMunicipio = usuario.IdMunicipio;
                            rowUsuario.Direccion.Colonia.Municipio.Nombre = usuario.NombreMunicipio;
                            rowUsuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            rowUsuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuario.IdEstado;
                            rowUsuario.Direccion.Colonia.Municipio.Estado.Nombre = usuario.NombreEstado;
                            rowUsuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            rowUsuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuario.IdPais;
                            rowUsuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = usuario.NombrePais;

                            usuarioGet.Usuarios.Add(rowUsuario);
                        }
                        return (true, null, usuarioGet, null);
                    }
                    else
                    {
                        throw new Exception("There ARE NOT elements");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, usuarioGet, ex);
            }
        }
        public static (bool, string, ML.Usuario, Exception) GetByIdEF(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetById(idUsuario).SingleOrDefault();

                    if (objUsuario != null)
                    {
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento;
                        usuario.CURP = objUsuario.CURP;
                        usuario.Imagen = objUsuario.Imagen;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol;
                        usuario.Rol.Nombre = objUsuario.NombreRol;
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia;
                        usuario.Direccion.Colonia.Nombre = objUsuario.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;

                        return (true, null, usuario, null);
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
        public static (bool Correct, string ErrorTxt, ML.Usuario Usuario, Exception Error) GetByEmailEF(string email)
        {
            try{
                using(DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    var usuario = context.UsuarioGetByEmail(email).SingleOrDefault();

                    if(usuario != null)
                    {
                        ML.Usuario usuarioGet = new ML.Usuario();
                        usuarioGet.IdUsuario = usuario.IdUsuario;
                        usuarioGet.Email = usuario.Email;
                        usuarioGet.Password = usuario.Password;
                        usuarioGet.Nombre = usuario.Nombre;
                        return (true, null, usuarioGet, null);
                    }
                    else
                    {
                        return (false, "No existe en la BD", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }

        public static (bool, string, Exception) UpdateEstatus(int idUsuario, bool estatus)
        {
            try
            {
                using (DL_EF.MFloresProgramacionNCapasEntities context = new DL_EF.MFloresProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioUpdateEstatus(idUsuario, estatus);
                    if(rowAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, "Fallo al actualizar", null);
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
