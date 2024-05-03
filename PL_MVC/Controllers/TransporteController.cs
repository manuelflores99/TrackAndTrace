using PL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class TransporteController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = BL.Transporte.GetAllLinq();
            if (result.Item1)
            {
                ML.Transporte transporte = new ML.Transporte();
                transporte.Transportes = result.Item3;
                return View(transporte);
            }
            else
            {
                @ViewBag.Message = "Error: " + result.Item2;
                return PartialView("Modal");
            }
        }
        [HttpGet]
        public ActionResult Form(int? idTransporte)
        {
            var resultEstatus = BL.EstatusTransporte.GetAll();
            ML.Transporte transporte = new ML.Transporte();
            

            if(idTransporte != null)
            {
                var resultTransporte = BL.Transporte.GetById(idTransporte.Value);
                transporte = resultTransporte.Item3;
                transporte.Estatus.EstatusTransportes = resultEstatus.Item3;
            }
            else
            {
                transporte.Estatus = new ML.EstatusTransporte();
                transporte.Estatus.EstatusTransportes = resultEstatus.Item3;
            }

            return View(transporte);
        }
        [HttpPost]
        public ActionResult Form(ML.Transporte transporte)
        {
            if(transporte.IdTransporte != 0)
            {
                var result = BL.Transporte.UpdateEF(transporte);
                if (result.Item1)
                {
                    ViewBag.Message = "Se ha actualizado con exito";
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Item2;
                }
            }
            else
            {
                var result = BL.Transporte.Add(transporte);
                if (result.Item1)
                {
                    ViewBag.Message = "Registro exitoso";
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Item2;
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int idTransporte)
        {
            var result = BL.Transporte.Delete(idTransporte);
            if (result.Item1)
            {
                ViewBag.Message = "Registro eliminado";
            }
            else
            {
                ViewBag.Message = "Error: " + result.Item2;
            }
            return PartialView("Modal");
        }

        //AssignRepartidor
        [HttpGet]
        public JsonResult getRepartidores()
        {
            var result = BL.Transporte.GetRepartidoresWithAsignaciones();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveAssign(int idTransporte, int idRepartidor)
        {
            Result result = new Result();

            var exe = BL.Transporte.SaveAssign(idTransporte, idRepartidor);

            result.Success = exe.Success;
            result.Message = exe.Message;
            result.Error = exe.Error;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}