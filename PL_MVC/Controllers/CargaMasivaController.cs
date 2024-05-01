using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            ML.ResultExcel excel = new ML.ResultExcel();
            return View(excel);
        }
        [HttpPost]
        public ActionResult Get(int? no)
        {
            if (Session["pathArchivo"] == null)
            {
                HttpPostedFileBase file = Request.Files["archivo"];
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    if (extension == ConfigurationManager.AppSettings["tipoExcel"].ToString())
                    {
                        if (file.ContentLength > 0)
                        {
                            string pathFolder = ConfigurationManager.AppSettings["pathFolderCargaMasiva"].ToString();
                            string pathArchivo = Server.MapPath(pathFolder) + Path.GetFileNameWithoutExtension(file.FileName) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            if (!System.IO.File.Exists(pathArchivo))
                            {
                                file.SaveAs(pathArchivo);
                                string contex = ConfigurationManager.AppSettings["connectionStringExcel"].ToString() + pathArchivo;
                                var result = BL.Paquete.CargaMasivaExcel(contex);
                                if (result.Item1)
                                {
                                    var resultValidacion = BL.Paquete.ExcelValidation(result.Item3);
                                    if (resultValidacion.Item1.Errores.Count > 0)
                                    {
                                        return View(resultValidacion.Item1);
                                    }
                                    else
                                    {
                                        Session["pathArchivo"] = pathArchivo;
                                        return View(resultValidacion.Item1);
                                    }
                                }
                                else ViewBag.Message = "Error: " + result.Item2;
                            }
                            else ViewBag.Message = "Intenta nuevamente en 1 minuto";
                        }
                        else ViewBag.Message = "El archivo está vacio";
                    }
                    else ViewBag.Message = "Archivo no compatible";
                }
                else ViewBag.Message = "No se cargo el archivo";
            }
            else
            {
                string pathArchivo = Session["pathArchivo"].ToString();

                string connectionString = ConfigurationManager.AppSettings["connectionStringExcel"].ToString() + pathArchivo;

                var result = BL.Paquete.CargaMasivaExcel(connectionString);
                if (result.Item1)
                {
                    foreach (ML.Paquete paquete in result.Item3)
                    {
                        BL.Paquete.Add(paquete);
                    }
                    ViewBag.Message = "Datos guardados exitosamente";
                    Session["pathArchivo"] = null;
                }
                else ViewBag.Message = "Fallo al subir datos";
            }
            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult CargaTXT()
        {
            HttpPostedFileBase file = Request.Files["fileTXT"];
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    if (extension == ".txt")
                    {
                        string pathFoler = @"C:\Users\digis\Documents\JOSE MANUEL FLORES HERNANDEZ\MFloresProgramacionNCapas\PL\CargaMasiva\";

                        string pathArchivo = pathFoler + Path.GetFileNameWithoutExtension(file.FileName) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                        if (!System.IO.File.Exists(pathArchivo))
                        {
                            file.SaveAs(pathArchivo);
                            StreamReader reader = new StreamReader(pathArchivo);

                            string linea;
                            int registrosExitosos = 0, registrosFallidos = 0;
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
                                    registrosExitosos++;
                                }
                                else
                                {
                                    registrosFallidos++;
                                }
                            }
                            ViewBag.Message = "Registros exitoso: " + registrosExitosos + "\nRegistros fallidos: " + registrosFallidos;
                        }
                        else ViewBag.Message = "Archivo no guardado";
                    }
                    else ViewBag.Message = "Archivo no compatible";
                }
                else ViewBag.Message = "No tiene información el documento subido";
            }
            else ViewBag.Message = "No se cargo el documento";
            return PartialView("Modal");
        }
    }
}