using Datos;
using Ejemplo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejemplo1.Controllers
{
    public class DeviceController : Controller
    {
        // GET: Device

        public ActionResult ShowRegister()
        {
            var modelo = new Models.DeviceView();
            modelo.sensores = new List<Models.Device>();
            ViewBag.error = false;
            try
            {
                using (var context = new Datos.DatosEntities())
                {
                    var us = context.SensorDevice.ToArray();
                    foreach (var u in us)
                    {
                        modelo.sensores.Add(new Models.Device
                        {
                            ID_REG = u.ID_REG,
                            ID_SENSOR = u.ID_SENSOR,
                            MEDICION = (float)u.MEDICION,
                            FECHAYHORA = DateTime.Parse(u.FECHAYHORA)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = true;
                ViewBag.mensaje = "Error:" + ex.Message.ToString();
            }
            var r = View(modelo);
            return r;
        }

        public string GetDateTime(int id)
        {
            try
            {
                
                var autorizatedID = new List<int> { 33, 22, 11, 99 };
                if (!autorizatedID.Exists(X => X == id)) throw new Exception("Device: ID Desconocido");
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                return "ERROR:" + ex.Message;
            }
        }

        [HttpPut]
        public string PutData(int id, string MEDICION, string FECHAYHORA)
        {

            try
            {
                var respuesta = new { Resultado = "OK", MEDICION = MEDICION, FECHAYHORA = FECHAYHORA, Id = id };
                var Numero = float.Parse(respuesta.MEDICION);
                

                using (var context = new DatosEntities())
                {
                    context.SensorDevice.Add(new Datos.SensorDevice
                    {
                        ID_SENSOR = respuesta.Id,
                        MEDICION = Numero,
                        FECHAYHORA = respuesta.FECHAYHORA,
                    });
                    context.SaveChanges();
                }
                    return respuesta.Id + " " + respuesta.MEDICION + " " + respuesta.FECHAYHORA + " " + respuesta.Resultado;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}

/*
            var modelo = new Models.DeviceView();
            modelo.sensores = new List<Models.Device>();
            try
            {
                using (var context = new Datos.DatosEntities())
                {
                    var us = context.SENSORDEVICEs.ToArray();
                    foreach (var u in us)
                    {
                        modelo.sensores.Add(new Models.Device
                        {
                            ID = u.ID,
                            MEDICION =(float) u.MEDICION,
                            FECHAYHORA = u.FECHAYHORA
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                
                return "Error:" + ex.Message;
            }




  
 */