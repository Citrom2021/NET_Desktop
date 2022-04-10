using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetProducts
{
    class Products
    {
        public int ID { get; set; }
        public string name { get; set; }

        public string category { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }

        public string created_at { get; set; }

        public string updated_at { get; set; }
    }
}
