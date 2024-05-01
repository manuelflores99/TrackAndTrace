using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Paquete
    {
        public static void CargaMasiva()
        {
            try
            {
                string path = @"C:\Users\digis\Documents\JOSE MANUEL FLORES HERNANDEZ\MFloresProgramacionNCapas\Paquetes10.txt";
                if (File.Exists(path))
                {
                    StreamReader reader = new StreamReader(path);
                    string linea;
                    reader.ReadLine();
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] datos = linea.Split('|');
                        ML.Paquete paquete = new ML.Paquete();
                        paquete.InstruccionEntrega = datos[0];
                        paquete.Peso = decimal.Parse(datos[1]);
                        paquete.DireccionOrigen = datos[2];
                        paquete.DireccionEntrega = datos[3];
                        paquete.FechaEstimadaEntrega = DateTime.Parse(datos[4]);
                        paquete.NumeroGuia = datos[5];
                        var result = BL.Paquete.Add(paquete);
                        if (result.Item1)
                        {
                            Console.WriteLine("Registro exitoso");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo guardar else registro");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("---------------- Archivo no encontrdo ----------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
