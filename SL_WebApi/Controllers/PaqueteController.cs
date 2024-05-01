using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class PaqueteController : ApiController
    {
        [HttpPost]
        [Route("api/Paquete/Add")]
        public IHttpActionResult Add([FromBody]ML.Paquete paquete)
        {
            var result = BL.Paquete.Add(paquete);
            if (result.Item1)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Paquete/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Paquete.GetAll();
            if(result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [HttpGet]
        [Route("api/Paquete/GetById")]
        public IHttpActionResult GetById(int idPaquete)
        {
            var result = BL.Paquete.GetById(idPaquete);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [HttpPut]
        [Route("api/Paquete/Update")]
        public IHttpActionResult Update([FromBody]ML.Paquete paquete)
        {
            var result = BL.Paquete.Update(paquete);
            if(result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [HttpDelete]
        [Route("api/Paquete/Delete")]
        public IHttpActionResult Delete(int idPaquete)
        {
            var result = BL.Paquete.Delete(idPaquete);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
