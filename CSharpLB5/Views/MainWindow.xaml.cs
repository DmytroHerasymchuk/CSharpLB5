using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSharpLB5.ViewModels;

namespace CSharpLB5.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListOfProducts.ItemsSource = _viewModel.Shop.Products;
            ListOfClients.ItemsSource = _viewModel.Clients;
            _viewModel.IsEnabled = true;
            OpenButton.IsEnabled = true;
            CloseButton.IsEnabled = true;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _viewModel.IsEnabled = true;
            _viewModel.Shop.IsOpen = true;
            _viewModel.ClientsBuyProductsAsync();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _viewModel.IsEnabled = true;
            _viewModel.Shop.IsOpen = false;
            _viewModel.BuyProductsToShopAsync();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _viewModel.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _viewModel.Shop.Logger.Close();
        }
    }
}
