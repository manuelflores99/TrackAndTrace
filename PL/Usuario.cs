using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        //public static void Add()
        //{
        //    ML.Usuario usuario = new ML.Usuario();

        //    Console.WriteLine("********** Crear nuevo registro de usuario **********");
        //    Console.WriteLine("Ingresa tu nombre de usuario:");
        //    usuario.UserName = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu nombre");
        //    usuario.Nombre = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu apellido paterno");
        //    usuario.ApellidoPaterno = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu apellido materno");
        //    usuario.ApellidoMaterno = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu dirección de correo electrónico:");
        //    usuario.Email = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu contraseña");
        //    usuario.Password = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu fecha de nacimento YYYY-MM-DD");
        //    usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
        //    Console.WriteLine("Indica tu sexo con H si eres hombre o M si eres mujer");
        //    usuario.Sexo = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu número telefónico:");
        //    usuario.Telefono = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu rol {1 = Admin, 2 = Usuario y 3 = Invitado}");
        //    usuario.Rol = new ML.Rol();
        //    usuario.Rol.IdRol = int.Parse(Console.ReadLine());

        //    var result = BL.Usuario.AddEF(usuario);

        //    if (result.Item1)
        //    {
        //        Console.WriteLine("Registro exitoso");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error\n" + result.Item2 + "\n" + result.Item3);
        //    }
        //}
        //public static void Update()
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    Console.WriteLine("********** Actualiza tu usuario **********");
        //    Console.WriteLine("Escribre tu ID:");
        //    usuario.IdUsuario = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Escribre tu nuevo nombre de usuario:");
        //    usuario.UserName = Console.ReadLine();
        //    Console.WriteLine("Escribre tu nuevo nombre:");
        //    usuario.Nombre = Console.ReadLine();
        //    Console.WriteLine("Escribre tu nuevo apellido paterno:");
        //    usuario.ApellidoPaterno = Console.ReadLine();
        //    Console.WriteLine("Escribre tu nuevo apellido materno:");
        //    usuario.ApellidoMaterno = Console.ReadLine();
        //    Console.WriteLine("Escribre tu nuevo Email:");
        //    usuario.Email = Console.ReadLine();
        //    Console.WriteLine("Escribe tu nueva contraseña:");
        //    usuario.Password = Console.ReadLine();
        //    Console.WriteLine("Escribe tu nueva fecha de nacimiento YYYY-MM-DD:");
        //    usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
        //    Console.WriteLine("Escribe tu nuevo sexo:");
        //    usuario.Sexo = Console.ReadLine();
        //    Console.WriteLine("Escribe tu nuevo número telefónico:");
        //    usuario.Telefono = Console.ReadLine();
        //    Console.WriteLine("Ingresa tu nuevo rol {1 = Admin, 2 = Usuario y 3 = Invitado}");
        //    usuario.Rol = new ML.Rol();
        //    usuario.Rol.IdRol = int.Parse(Console.ReadLine());

        //    var result = BL.Usuario.UpdateEF(usuario);

        //    if (result.Item1)
        //    {
        //        Console.WriteLine("********** Actualización exitosa **********");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error");
        //        Console.WriteLine(result.Item2 + "\n" + result.Item3);
        //    }
        //}
        //public static void Delete()
        //{
        //    Console.WriteLine("********** Ingresa el ID del registro a eleminar **********");
        //    int idUsuario = int.Parse(Console.ReadLine());
        //    int idDireccion = int.Parse(Console.ReadLine());

        //    var result = BL.Usuario.DeleteEF(idUsuario, idDireccion);

        //    if (result.Item1)
        //    {
        //        Console.WriteLine("Eliminación exitosa");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error:");
        //        Console.WriteLine(result.Item2 + "\n" + result.Item3);
        //    }
        //}
        //public static void GetAll()
        //{
        //    var results = BL.Usuario.GetAllEF();

        //    if (results.Item1)
        //    {
        //        foreach (ML.Usuario usuario in results.Item3.Usuarios)
        //        {
        //            Console.WriteLine("Id: " + usuario.IdUsuario + "\nUsername: " + usuario.UserName + "\nNombre: " + usuario.Nombre
        //                                + "\nApellido Paterno: " + usuario.ApellidoPaterno + "\nApellido Materno: " + usuario.ApellidoMaterno
        //                                    + "\nEmail: " + usuario.Email + "\nFecha de Nacimiento: " + usuario.FechaNacimiento + "\nSexo: "
        //                                        + usuario.Sexo + "Telefono: " + usuario.Telefono + "\nRol: " + usuario.Rol.Nombre);
        //            Console.WriteLine("-----------------------------------------------------------");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrio un error: " + results.Item2);
        //        Exception ex = results.Item4;
        //    }

        //}
        //public static void GetById()
        //{
        //    Console.WriteLine("********** Ingresa el ID a buscar **********");
        //    int idUsuario = int.Parse(Console.ReadLine());

        //    var result = BL.Usuario.GetByIdEF(idUsuario);

        //    /// pendiente

        //    if (result.Item1)
        //    {
        //        Console.WriteLine("Id: " + result.Item3.IdUsuario + "\nNombre de usuario: " + result.Item3.UserName + "\nNombre: " + result.Item3.Nombre
        //                        + "\nApellido Paterno: " + result.Item3.ApellidoPaterno + "\nApellido Materno: " + result.Item3.ApellidoMaterno
        //                            + "\nCorreo: " + result.Item3.Email + "\nFecha de nacimiento: " + result.Item3.FechaNacimiento + "\nSexo: " + result.Item3.Sexo
        //                                + "\nTeléfono: " + result.Item3.Telefono + "\nRol: " + result.Item3.Rol.Nombre);
        //        Console.WriteLine("-----------------------------------------------------------");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrio un error: " + result.Item2);
        //        Exception ex = result.Item4;
        //    }
        //}
    }
}
