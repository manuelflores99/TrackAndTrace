using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AsistenciaController : Controller
    {
        // GET: Asistencia
        public ActionResult Form()
        {
            ML.Asistencia asistencia = new ML.Asistencia();
            asistencia.Estatus = new ML.EstatusAsistencia();
            return View(asistencia);
        }

        [HttpPost]
        public ActionResult Form(ML.Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                TempData["method"] = "Form";
                TempData["controller"] = "Asistencia";
                ViewBag.Message = "Revisa en tu correo nuestro mensaje de confirmación en tu bandeja de entrada o correo no deseado";
                asistencia.Estatus = new ML.EstatusAsistencia();



                var result = BL.Asistencia.Add(asistencia);

                
                if (result.Success)
                {
                    string path = Server.MapPath("~/Content/Template/SolicitudEnviada.html");

                    string body = string.Empty;

                    using(StreamReader reader = new StreamReader(path))
                    {
                        body = reader.ReadToEnd();
                    }

                    body = body.Replace("{numeroSeguimiento}", asistencia.NumeroSeguimiento);

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("fhjosemanuel@gmail.com", "eswfmvxknkgcpcyg"),
                        EnableSsl = true
                    };

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(asistencia.Email),
                        Subject = "Solicitud de asistencia/soporte",
                        Body = body,
                        IsBodyHtml = true
                    };

                    mail.To.Add(asistencia.Email);

                    smtp.Send(mail);
                }
                else
                {
                    ViewBag.Message = "No pudimos registrar tu solicitud, intenta más tarde";
                }
                return PartialView("~/Views/Modal/general.cshtml");
            }
            else
            {
                return View(asistencia);
            }
        }
    }
}