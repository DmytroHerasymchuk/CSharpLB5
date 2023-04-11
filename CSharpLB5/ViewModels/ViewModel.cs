using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLB5.Models;

namespace CSharpLB5.ViewModels
{
    public class ViewModel
    {
        public Shop Shop { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public bool IsEnabled { get; set; }
        public ViewModel()
        {
            Shop shop = new Shop();
            Clients = new ObservableCollection<Client>();
            Shop = shop;
        }

        public async void BuyProductsToShopAsync()
        {
            while (!Shop.IsOpen && IsEnabled)
            {
                Shop.BuyProductToShop();
                await Task.Delay(1000);
            }
        }

        public async void ClientsBuyProductsAsync()
        {
            while (Shop.IsOpen && IsEnabled)
            {
                Client client = Shop.GenerateClient();
                if (CheckIfProductInShop(client))
                {
                    Shop.BuyProductToClient(client);
                }
                
                Clients.Add(client);
                
                await Task.Delay(5000);
                
            }
        }
        private bool CheckIfProductInShop(Client client)
        {
            ProductQuantity productToBuy = GetProductQuantity(client.ProductWant.Product.Name);
            if (productToBuy.Quantity >= client.ProductWant.Quantity)
            {               
                return true;
            }
            return false;
        }

        private ProductQuantity GetProductQuantity(string productName)
        {
            return Shop.Products.FirstOrDefault(product => productName == product.Product.Name);
        }


    }
}
