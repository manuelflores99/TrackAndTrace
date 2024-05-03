using SL_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class TransporteController : ApiController
    {
        [HttpPost]
        [Route("api/Transporte/AsignarRepartidor")]
        public IHttpActionResult AsignarRepartidor(ML.Transporte transporte)
        {
            Result result = new Result();
            if(transporte.IdTransporte != 0 && transporte.Repartidor.IdRepartidor != 0)
            {
                var send = BL.Transporte.AssignRepartidor(transporte);

                result.Success = send.Success;

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    result.Message = send.Message;
                    result.Error = send.Error;
                    return Content(HttpStatusCode.BadRequest, result);
                }
            }
            else
            {
                result.Message = "Hay que proporccionar el identificador del transporte y del repartidor";
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
