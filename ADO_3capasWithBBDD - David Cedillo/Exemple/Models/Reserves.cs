using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Reserves
    {
        public int Id { get; set; }
        public string Nom_empresa { get; set; }
        public DateTime Data { get; set; }

        public int Llocs_de_treball { get; set; }
        public String Equip_informatic { get; set; }

        public int Tel { get; set; }

        public string Obs { get; set; }
    }
}
