using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889854.Actividad03
{
    class AsientoDiario
    {
        public int NroAsiento { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoCuenta { get; set; }
        public Double Debe { get; set; }
        public Double Haber { get; set; }

        //constructor
        public AsientoDiario(string informacionAsientoDiario)
        {
            string[] data = informacionAsientoDiario.Split('|');
            // Parsear data a propiedades.
            this.NroAsiento = Convert.ToInt32(data[0]);
            this.Fecha = Convert.ToDateTime(data[1]);
            this.CodigoCuenta = Convert.ToInt32(data[2]);
            this.Debe = Convert.ToDouble(data[3]);
            this.Haber = Convert.ToDouble(data[4]);
        }

        //override del método ToString para escribir datos
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}", NroAsiento, Fecha.ToShortDateString(), CodigoCuenta, Debe, Haber);
        }
    }
}
