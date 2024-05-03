using SL_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class EstatusAsistenciaController : ApiController
    {
        [HttpGet]
        [Route("api/Asistencia/GetAll")]
        public IHttpActionResult GetAll()
        {
            var getEstados = BL.EstatusAsistencia.GetAll();

            if (getEstados.Success)
            {
                Result result = new Result();
                result.Success = getEstados.Success;
                result.Data = getEstados.Estatus;
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
