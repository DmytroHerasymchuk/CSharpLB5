using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLB5.Models
{
    public class Client
    {
        public string Name { get; set; }
        public ProductQuantity ProductWant { get; set; }
        private List<string> _names = new List<string>
        {
            "Tom",
            "Nick",
            "Kate",
            "Joe",
            "Ann",
        };
        private List<Product> _products = new List<Product>
        {
            new Product("Apple",15,17),
            new Product("Banana",20,23),
            new Product("Potata",5,6),
            new Product("Orange",21,23),
            new Product("Carrot",7,9),
            new Product("Onion",11,13),
            new Product("Tomato",24,26)
        };
        public Client()
        {
            Random random = new Random();
            Name = _names[random.Next(0, _names.Count)];
            ProductWant = new ProductQuantity(_products[random.Next(0, _products.Count)], random.Next(1, 4));

        }
    }
}
