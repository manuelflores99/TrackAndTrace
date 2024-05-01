using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AsignacionController : Controller
    {
        [HttpGet]
        public ActionResult GetAll(int? idPaquete)
        {
            if (idPaquete != null)
            {
                bool showRepartidores;
                if (Session["Asignaciones"] == null) showRepartidores = true;
                else
                {
                    ML.Asignacion asignacion = (ML.Asignacion)Session["Asignaciones"];
                    bool selectRepartidor = false;
                    bool salir = false;
                    foreach (var asig in asignacion.Asignaciones)
                    {
                        if (!salir)
                        {
                            foreach (ML.Paquete paquete in asig.Paquete.Paquetes)
                            {
                                if (paquete.IdPaquete == idPaquete)
                                {
                                    ViewBag.Message = "El paquete ya fue asignado";
                                    selectRepartidor = false;
                                    salir = true;
                                    break;
                                }
                                else selectRepartidor = true;
                            }
                        }
                        else break;
                    }
                    showRepartidores = selectRepartidor ? true : false;
                    
                }
                if (showRepartidores)
                {
                    var resultPaquete = BL.Paquete.GetById(idPaquete.Value);
                    ViewBag.NumeroGuia = resultPaquete.Item3.NumeroGuia.ToString();
                    ViewData["idPaquete"] = idPaquete.Value;

                    var resulRepartidor = BL.Repartidor.GetAll();
                    ML.Repartidor repartidor = new ML.Repartidor();
                    repartidor.Repartidores = resulRepartidor.Item3;
                    return View(repartidor);
                }
                else return PartialView("Modal");
            }
            else return RedirectToAction("GetAll", "Paquete");
        }
        [HttpGet]
        public ActionResult AddToSession(int idPaquete, int idRepartidor)
        {
            if (Session["Asignaciones"] == null)
            {
                ML.Asignacion asignacion = new ML.Asignacion();
                asignacion.Asignaciones = new List<ML.Asignacion>();

                var resultRepartidor = BL.Repartidor.GetById(idRepartidor);
                var resultPaquete = BL.Paquete.GetById(idPaquete);

                ML.Paquete paquete = resultPaquete.Item3;
                paquete.Repartidor = new ML.Repartidor();
                paquete.Repartidor.IdRepartidor = idRepartidor;

                asignacion.Paquete = new ML.Paquete();
                asignacion.Paquete.Paquetes = new List<ML.Paquete>() { paquete };

                asignacion.Repartidor = resultRepartidor.Item3;
                asignacion.Asignaciones.Add(asignacion);
                Session["Asignaciones"] = asignacion;
            }
            else
            {
                ML.Asignacion asignacion = (ML.Asignacion)Session["Asignaciones"];
                bool existeRepartidor = false;
                foreach(ML.Asignacion query in asignacion.Asignaciones)
                {
                    if(query.Repartidor.IdRepartidor == idRepartidor)
                    {
                        existeRepartidor = true;
                        query.TotalPaquete++;
                        var resultPaquete = BL.Paquete.GetById(idPaquete);
                        query.Paquete.Paquetes.Add(resultPaquete.Item3);
                        break;
                    }
                }
                if (!existeRepartidor)
                {
                    ML.Asignacion newAsignacion = new ML.Asignacion();
                    var resultRepartidor = BL.Repartidor.GetById(idRepartidor);
                    var resultPaquete = BL.Paquete.GetById(idPaquete);

                    ML.Paquete paquete = resultPaquete.Item3;
                    paquete.Repartidor = new ML.Repartidor();
                    paquete.Repartidor.IdRepartidor = idRepartidor;

                    newAsignacion.Paquete = new ML.Paquete();
                    newAsignacion.Paquete.Paquetes = new List<ML.Paquete>() { paquete };

                    newAsignacion.Repartidor = resultRepartidor.Item3;
                    asignacion.Asignaciones.Add(newAsignacion);
                    Session["Asignaciones"] = asignacion;
                }
            }
            ViewBag.Message = "Se ha agregado correctamente";
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Asignaciones()
        {
            ML.Asignacion asignacion = new ML.Asignacion();
            if (Session["Asignaciones"] == null)
            {
                return View(asignacion);
            }
            else
            {
                asignacion = (ML.Asignacion)Session["Asignaciones"];
                return View(asignacion);
            }
        }
    }
}