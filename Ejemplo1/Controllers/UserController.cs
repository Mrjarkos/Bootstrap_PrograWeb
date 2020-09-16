using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejemplo1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Load()
        {
            return View();
        }

        public ActionResult Modify()
        {
            return View();
        }

        // POST: User
        [HttpPost]
        public ActionResult Guardar(Models.Usuario usuario)
        {
            try
            {
                ViewBag.error = false;
                if (ModelState.IsValid)
                {
                    Datos.Interfaces.clsUsuario admin = new Datos.Interfaces.clsUsuario();
                    admin.Insertar(new Datos.USUARIO {
                        PASSWORD=usuario.PASSWORD,
                        CORREO = usuario.CORREO,
                        DOCUMENTO = usuario.DOCUMENTO,
                        DOC_TYPE = usuario.DOC_TYPE,
                        NOMBRE = usuario.NOMBRE,
                        ROL = usuario.ROL, 
                        ID = usuario.ID
                    });
                    ViewBag.mensaje = "Usuario guardado exitosamente";
                }
                else {
                    throw new Exception("El modelo no es válido");
                }
                
            }
            catch(Exception ex){
                ViewBag.error = true;
                ViewBag.mensaje = "Error:"+ex.Message.ToString();
            }
            
            return View("Add");
        }
    }
}