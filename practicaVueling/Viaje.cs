using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaVueling
{
    public class Viaje
    {
        public string CiudadOrigenIda { get; set; }
         public string CiudadDestinoIda { get; set; }
         public DateTime FechaIda { get; set; }
         public TimeSpan HoraIda { get; set; }
         public int PasajerosIda { get; set; }
         public string CiudadOrigenRegreso { get; set; }
         public string CiudadDestinoRegreso { get; set; }
         public DateTime FechaRegreso { get; set; }
         public TimeSpan HoraRegreso { get; set; }
         public int PasajerosRegreso { get; set; }
         public double PrecioTotal { get; set; }
    }
}
