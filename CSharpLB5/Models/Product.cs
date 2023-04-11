using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLB5.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int PriceForShop { get; set; }
        public int PriceForClient { get; set; }

        public Product(string name, int priceForShop, int priceForClient)
        {
            Name = name;
            PriceForShop = priceForShop;
            PriceForClient = priceForClient;
        }
    }
}
