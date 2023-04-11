using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CSharpLB5.Service;

namespace CSharpLB5.Models
{
    public class Shop : INotifyPropertyChanged
    {
        private int _paydesk;
        public Logger Logger;
        public bool IsOpen { get; set; }
        public int Paydesk
        {
            get { return _paydesk; }
            set
            {
                _paydesk = value;
                OnPropertyChanged(nameof(Paydesk));
            }
        }
        public ObservableCollection<ProductQuantity> Products { get; set; }
        public Shop()
        {
            IsOpen = false;
            Paydesk = 100;
            Products = new ObservableCollection<ProductQuantity>
            {
                new ProductQuantity(new Product("Apple",15,17), 10),
                new ProductQuantity(new Product("Banana",20,23), 10),
                new ProductQuantity(new Product("Potata",5,6), 10),
                new ProductQuantity(new Product("Orange",21,23), 10),
                new ProductQuantity(new Product("Carrot",7,9), 10),
                new ProductQuantity(new Product("Onion",11,13), 10),
                new ProductQuantity(new Product("Tomato",24,26), 10)
            };
            Logger = new Logger("logs.xml");
        }

        public void BuyProductToShop()
        {
            Random rand = new Random();
            Product product = Products[rand.Next(0, Products.Count)].Product;
            if ((Paydesk - product.PriceForShop) >= 0)
            {
                Products.FirstOrDefault(prod => prod.Product.Name == product.Name).Quantity++;
                Paydesk -= product.PriceForShop;
                Logger.Log($"Shop bought {product.Name} for {product.PriceForShop}");
                
            }
        }

        public void BuyProductToClient(Client client)
        {
            Products.FirstOrDefault(product => client.ProductWant.Product.Name == product.Product.Name).Quantity -= client.ProductWant.Quantity;
            int price = client.ProductWant.Product.PriceForClient * client.ProductWant.Quantity;
            Paydesk += price;
            Logger.Log($"{client.Name} bought {client.ProductWant.Quantity} {client.ProductWant.Product.Name} for {price}");
            
        }

        public Client GenerateClient()
        {
            return new Client();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
