using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejemplo1.Models
{
    public class Device
    {
        public virtual int ID_REG { get; set; }
        public int ID_SENSOR { get; set; }
        public float MEDICION { get; set; }
        public DateTime FECHAYHORA { get; set; }
    }
}