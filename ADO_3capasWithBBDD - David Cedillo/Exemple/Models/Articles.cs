using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Articles
    {
        public int IdArticle { get; set; }
        public String ArticleName { get; set; }
        public float UnitPrice { get; set; }
        public int Availability { get; set; }
    }
}
