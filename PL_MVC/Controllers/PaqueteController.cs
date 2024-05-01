using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PaqueteController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            //var result = BL.Paquete.GetAll(); // Petición directa
            //using (HttpClient cliente = new HttpClient()) // Petición por WebApi REST
            //{
            //    cliente.BaseAddress = new Uri("http://localhost:61044/api/");
            //    var taskResult = cliente.GetAsync("Paquete/GetAll");
            //    taskResult.Wait();

            //    var result = taskResult.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var contentResult = result.Content.ReadAsAsync<(bool Correct, string ErrorTxt, List<ML.Paquete> ListaPaquetes, Exception Error)>();

            //        var readContent = contentResult.Result;
            //        if (readContent.Correct)
            //        {
            //            ML.Paquete paquete = new ML.Paquete();
            //            List<ML.Paquete> paquetes = contentResult.Result.ListaPaquetes;
            //            paquete.Paquetes = paquetes;
            //            return View(paquete);
            //        }
            //        else
            //        {
            //            ML.Paquete paquete = new ML.Paquete();
            //            return View(paquete);
            //        }
            //    }
            //    else
            //    {
            //        ViewBag.Message = "Error al realizar la petición";
            //        return PartialView("Modal");
            //    }
            //}

            ServiceReferencePaquete.PaqueteClient clientWCF = new ServiceReferencePaquete.PaqueteClient();
            var result = clientWCF.GetAll();
            ML.Paquete paquete = new ML.Paquete();
            if (result.Item1)
            {
                paquete.Paquetes = result.Item3.ToList();
            }
            return View(paquete);
        }
        [HttpGet]
        public ActionResult Form(int? idPaquete)
        {
            ML.Paquete paquete = new ML.Paquete();
            if (idPaquete != null)
            {
                //var resultPaqueteById = BL.Paquete.GetById(idPaquete.Value);
                //using (HttpClient cliente = new HttpClient())
                //{
                //    cliente.BaseAddress = new Uri("http://localhost:61044/api/");
                //    var task = cliente.GetAsync("Paquete/GetById?idPaquete=" + idPaquete.Value);
                //    var taskResult = task.Result;

                //    if (taskResult.IsSuccessStatusCode)
                //    {
                //        var taskContent = taskResult.Content.ReadAsAsync<(bool Correct, string ErrorTXt, ML.Paquete Paquete, Exception Error)>();

                //        if (taskContent.Result.Correct)
                //        {
                //            paquete = taskContent.Result.Paquete;
                //        }
                //        else
                //        {
                //            ViewBag.Message = "No se realizo correctamente la solicitud, vuelve a intertarlo";
                //            return PartialView("Modal");
                //        }
                //    }
                //    else
                //    {
                //        ViewBag.Message = "No se realizo correctamente la petición, vuelve a intertarlo";
                //        return PartialView("Modal");
                //    }
                //}
                ServiceReferencePaquete.PaqueteClient clientWCF = new ServiceReferencePaquete.PaqueteClient();
                var result = clientWCF.GetById(idPaquete.Value);
                if (result.Item1) paquete = result.Item3;
                else
                {
                    ViewBag.Message = "Error: " + result.Item2;
                    return PartialView("Modal");
                }
            }
            return View(paquete);
        }
        [HttpPost]
        public ActionResult Form(ML.Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                if (paquete.IdPaquete != 0)
                {
                    //var result = BL.Paquete.Update(paquete);
                    //using(HttpClient client = new HttpClient())
                    //{
                    //    client.BaseAddress = new Uri("http://localhost:61044/api/");
                    //    var task = client.PutAsJsonAsync("Paquete/Update", paquete);
                    //    var taskResult = task.Result;

                    //    if (taskResult.IsSuccessStatusCode)
                    //    {
                    //        var taskContent = taskResult.Content.ReadAsAsync<(bool Correct, string ErrorTxt, Exception Error)>();
                    //        if (taskContent.Result.Correct) ViewBag.Message = "Actualización exitosa";
                    //        else ViewBag.Message = "Error: " + taskContent.Result.ErrorTxt;
                    //    }
                    //}
                    ServiceReferencePaquete.PaqueteClient clientPaquete = new ServiceReferencePaquete.PaqueteClient();
                    var result = clientPaquete.Update(paquete);
                    if (result.Item1) ViewBag.Message = "Información actualizada";
                    else ViewBag.Message = "Erro al guardar información: " + result.Item2;
                }
                else
                {
                    // var result = BL.Paquete.Add(paquete);
                    //or -start
                    //using (HttpClient cliente = new HttpClient())
                    //{
                    //    cliente.BaseAddress = new Uri("http://localhost:61044/api/");
                    //    var taskResult = cliente.PostAsJsonAsync<ML.Paquete>("Paquete/Add", paquete);
                    //    taskResult.Wait();
                    //    var result = taskResult.Result;

                    //    if (result.IsSuccessStatusCode)
                    //    {
                    //        var getJson = result.Content.ReadAsStringAsync();
                    //        string jsonString = getJson.Result;
                    //        var getResult = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
                    //        bool correct = getResult.Item1;
                    //        if (correct) ViewBag.Message = "Registro exitoso";
                    //        else ViewBag.Message = "Error: " + getResult.ErrorTxt;
                    //    }
                    //    else ViewBag.Message = "Error al realziar la petición";
                    //}
                    //-end

                    ServiceReferencePaquete.PaqueteClient clientPaquete = new ServiceReferencePaquete.PaqueteClient();
                    var result = clientPaquete.Add(paquete);
                    if (result.Item1) ViewBag.Message = "Registro exitoso";
                    else ViewBag.Message = "Error: " + result.Item2;
                }
                return PartialView("Modal");
            }
            else
            {
                return View(paquete);
            }
        }
        public ActionResult Delete(int idPaquete)
        {
            //var result = BL.Paquete.Delete(idPaquete);
            //using (HttpClient cliente = new HttpClient())
            //{
            //    cliente.BaseAddress = new Uri("http://localhost:61044/api/");
            //    var task = cliente.DeleteAsync("Paquete/Delete?idPaquete=" + idPaquete);
            //    task.Wait();

            //    var taskResult = task.Result;

            //    if (taskResult.IsSuccessStatusCode)
            //    {
            //        var taskContent = taskResult.Content.ReadAsAsync<(bool Correct, string ErrorTxt, Exception Error)>();
            //        if (taskContent.Result.Correct) ViewBag.Message = "Se ha eliminado con exito";
            //        else ViewBag.Message = "Error: " + taskContent.Result.ErrorTxt;
            //    }
            //    else ViewBag.Message = "Error al realizar la petición";
            //}
            ServiceReferencePaquete.PaqueteClient clientPaquete = new ServiceReferencePaquete.PaqueteClient();
            var result = clientPaquete.Delete(idPaquete);
            if (result.Item1) ViewBag.Message = "Registro eliminado";
            else ViewBag.Message = "Error: " + result.Item2;
            return PartialView("Modal");
        }
    }
}