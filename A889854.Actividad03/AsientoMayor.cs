using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889854.Actividad03
{
    class AsientoMayor
    {
        public int CodigoCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public Double Debe { get; set; }
        public Double Haber { get; set; }

        //constructor
        public AsientoMayor(string informacionAsientoMayor)
        {
            string[] data = informacionAsientoMayor.Split('|');
            // Parsear data a propiedades.
            this.CodigoCuenta = Convert.ToInt32(data[0]);
            this.Fecha = Convert.ToDateTime(data[1]);
            this.Debe = Convert.ToDouble(data[2]);
            this.Haber = Convert.ToDouble(data[3]);
        }

        //otro constructor.
        public AsientoMayor(int ccuenta, DateTime fecha, double debe, double haber)
        {
            this.CodigoCuenta = ccuenta;
            this.Fecha = fecha;
            this.Debe = debe;
            this.Haber = haber;
        }

        // override del método toString para escribir datos
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|", CodigoCuenta, Fecha.ToShortDateString(), Debe, Haber);
        }
    }
}
