using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public DateTime OrderDate { get; set; }
        public String PaymentMethod { get; set; }
        public int Discount { get; set; }
        public String Status { get; set; }
    }
}
