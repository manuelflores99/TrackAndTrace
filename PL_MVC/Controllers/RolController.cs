using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult GetAll()
        {
            var result = BL.Rol.GetAll();
            ML.Rol roles = result.Item3;
            return View(roles);
        }
        public ActionResult Form()
        {
            ML.Rol rol = new ML.Rol();
            return View(rol);
        }
    }
}