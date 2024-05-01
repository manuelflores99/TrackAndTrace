using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuarioBusquedad = new ML.Usuario();
            usuarioBusquedad.Nombre = "";
            usuarioBusquedad.ApellidoPaterno = "";
            usuarioBusquedad.ApellidoMaterno = "";

            var result = BL.Usuario.GetAllEF(usuarioBusquedad);
            if (result.Item1)
            {
                ML.Usuario usuarios = result.Item3;
                return View(usuarios);
            }
            else
            {
                ML.Usuario usuarios = new ML.Usuario();
                return View(usuarios);
            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuarioBusquedad)
        {
            usuarioBusquedad.Nombre = usuarioBusquedad.Nombre != null ? usuarioBusquedad.Nombre : "";
            usuarioBusquedad.ApellidoPaterno = usuarioBusquedad.ApellidoPaterno != null ? usuarioBusquedad.ApellidoPaterno : "";
            usuarioBusquedad.ApellidoMaterno = usuarioBusquedad.ApellidoMaterno != null ? usuarioBusquedad.ApellidoMaterno : "";
            var result = BL.Usuario.GetAllEF(usuarioBusquedad);
            if (result.Item1)
            {
                ML.Usuario usuarios = result.Item3;
                return View(usuarios);
            }
            else
            {
                ML.Usuario usuarios = new ML.Usuario();
                return View(usuarios);
            }
        }
        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            var resultRoles = BL.Rol.GetAll();
            var resulPaises = BL.Pais.GetAll();

            if (idUsuario != null) //Update
            {
                var result = BL.Usuario.GetByIdEF(idUsuario.Value);
                ML.Usuario usuario = result.Item3;

                usuario.Rol.Roles = resultRoles.Item3.Roles;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resulPaises.Item3.Paises;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Item3.Estados;
                usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Item3.Municipios;
                usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Item3;
                
                return View(usuario);
            }
            else //Create
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario.Rol = new ML.Rol();
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                usuario.Rol.Roles = resultRoles.Item3.Roles;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resulPaises.Item3.Paises;
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];

                if (file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirBase64(file);
                }
                if (usuario.IdUsuario != 0)
                {
                    var result = BL.Usuario.UpdateEF(usuario);
                    if (result.Item1)
                    {
                        ViewBag.Message = "Actualización exitosa";
                    }
                    else
                    {
                        ViewBag.Message = "Error: " + result.Item2;
                    }
                }
                else
                {
                    var result = BL.Usuario.AddEF(usuario);
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
            else
            {
                var resultRoles = BL.Rol.GetAll();
                var resulPaises = BL.Pais.GetAll();

                usuario.Rol.Roles = resultRoles.Item3.Roles;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resulPaises.Item3.Paises;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Item3.Estados;
                usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Item3.Municipios;
                usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Item3;

                return View(usuario);
            }
            
        }
        
        public string ConvertirBase64(HttpPostedFileBase Imagen)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            byte[] data = reader.ReadBytes((int)Imagen.ContentLength);
            string img = Convert.ToBase64String(data);
            return img;
        }
        [HttpGet]
        public ActionResult Delete(int idUsuario, int idDireccion)
        {
            var result = BL.Usuario.DeleteEF(idUsuario, idDireccion);

            if (result.Item1)
            {
                ViewBag.Message = "Se ha eliminado exitosamente";
            }
            else
            {
                ViewBag.Message = "Error: " + result.Item2;
            }
            return PartialView("Modal");
        }
        
        [HttpPost]
        public JsonResult EstadoGetByIdPais(int idPais)
        {
            var result = BL.Estado.GetByIdPais(idPais);

            if( result.Item1)
            {
                return Json(result.Item3.Estados, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult MunicipioGetByIdEStado(int idEstado)
        {
            var result = BL.Municipio.GetByIdEstado(idEstado);
            if (result.Item1)
            {
                return Json(result.Item3.Municipios, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult ColoniaGetByIdMunicipio(int idMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(idMunicipio);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult ColoniaGetById(int idColonia)
        {
            var result = BL.Colonia.GetById(idColonia);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CambiarEstatus(int idUsuario, bool estatus)
        {
            var result = BL.Usuario.UpdateEstatus(idUsuario, estatus);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}