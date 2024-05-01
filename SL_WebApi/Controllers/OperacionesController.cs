using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class OperacionesController : ApiController
    {
        [HttpGet]
        [Route("api/saludar")]
        public IHttpActionResult Saludar(string nombre)
        {
            string sendSaludo = "Hola " + nombre;
            return Content(HttpStatusCode.OK, sendSaludo);
        }

        [HttpGet]
        [Route("api/suma")]
        public IHttpActionResult Suma(double num1, double num2)
        {
            string sendText = "El resultado es: " + (num1 + num2);
            return Content(HttpStatusCode.OK, sendText);
        }

        [HttpGet]
        [Route("api/resta")]
        public IHttpActionResult Resta(double num1, double num2)
        {
            string sendText = "El resultado de la resta es: " + (num1 - num2);
            return Content(HttpStatusCode.OK, sendText);
        }

        [HttpGet]
        [Route("api/multiplicacion")]
        public IHttpActionResult Multiplicacion(double num1, double num2)
        {
            string sendText = "El resultado de la multipliacación es: " + (num1 * num2);
            return Content(HttpStatusCode.OK, sendText);
        }

        [HttpGet]
        [Route("api/division")]
        public IHttpActionResult Division(double num1, double num2)
        {
            string sendText = "El resultado de la división es: " + (num1 / num2);
            return Content(HttpStatusCode.OK, sendText);
        }
    }
}
