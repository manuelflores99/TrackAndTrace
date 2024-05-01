using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class AsistenciaController : ApiController
    {
        [HttpPost]
        [Route("api/Asistencia/Add")]
        public IHttpActionResult Add(ML.Asistencia asistencia)
        {
            var result = BL.Asistencia.Add(asistencia);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
