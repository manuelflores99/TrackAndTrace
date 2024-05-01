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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var result = BL.Usuario.GetByEmailEF(email);

            if (result.Item1)
            {
                if (result.Item3.Password == password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Contraseña incorrecta";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Message = "Usuario no existe";
                return PartialView("Modal");
            }
        }
        [HttpPost]
        public JsonResult Recuperar(string email)
        {
            var result = BL.Usuario.GetByEmailEF(email);
            if (result.Correct)
            {
                string path = Server.MapPath("~/Content/Template/RecuperarContrasenia.html");

                string body = string.Empty;

                using (StreamReader reader = new StreamReader(path))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{name}", result.Usuario.Nombre);
                body = body.Replace("{route}", "http://localhost:49395");
                body = body.Replace("{email}", email);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("fhjosemanuel@gmail.com", "eswfmvxknkgcpcyg"),
                    EnableSsl = true
                };

                var mensaje = new MailMessage
                {
                    From = new MailAddress(email),
                    Subject = "Recuperación de contraseña",
                    Body = body,
                    IsBodyHtml = true
                };

                mensaje.To.Add(email);

                smtp.Send(mensaje);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ReestablecerContrasenia(string email)
        {
            var result = BL.Usuario.GetByEmailEF(email);

            if(result.Correct)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario.Email = email;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = "El correo electrónico no existe";
                return PartialView("Modal");
            }
        }
        public ActionResult Restablecer(ML.Usuario usuario)
        {
            var resultEmail = BL.Usuario.GetByEmailEF(usuario.Email);

            if (resultEmail.Correct)
            {
                var result = BL.Usuario.GetByIdEF(resultEmail.Usuario.IdUsuario);
                ML.Usuario getUsuarioRegisted = result.Item3;
                getUsuarioRegisted.Password = usuario.Password;

                var update = BL.Usuario.UpdateEF(getUsuarioRegisted);

                if (update.Item1) ViewBag.Message = "Actualización exitosa";
                else ViewBag.Message = "No se actualizo exitosamente";
            }
            else ViewBag.Message = "Correo no encontrado, no se realizo la actualización";
            return PartialView("Modal");
        }
    }
}