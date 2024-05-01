using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goOut;
            do
            {
                Console.WriteLine("Menú\n1. Crear\n2. Actualizar\n3. Eliminar\n4. Leer Todo\n5. Buscar registro\n6. Carga Masiva");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        //PL.Usuario.Add();
                        break;
                    case 2:
                        //PL.Usuario.Update();
                        break;
                    case 3:
                        //PL.Usuario.Delete();
                        break;
                    case 4:
                        //PL.Usuario.GetAll();
                        break;
                    case 5:
                        //PL.Usuario.GetById();
                        break;
                    case 6:
                        PL.Paquete.CargaMasiva();
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                Console.WriteLine("¿Deseas realizar otra acción?\n1. Sí\n2. No");
                goOut = int.Parse(Console.ReadLine());
            } while (goOut == 1);
        }


    }
}
