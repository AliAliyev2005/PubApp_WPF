using PubApp_WPF.Command;
using PubApp_WPF.Models;
using PubApp_WPF.ViewModels;
using PubApp_WPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PubApp_WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public List<Product> Products { get; set; }
        public List<ProductHistory> ProductHistories { get; set; } = new List<ProductHistory>();
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }
        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { _product = value; OnPropertyChanged(); }
        }
        private int _productCount;
        public int ProductCount
        {
            get { return _productCount; }
            set { _productCount = value; OnPropertyChanged(); }
        }

        public RelayCommand IncreaseCommand { get; set; }
        public RelayCommand DecreaseCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ShowHistoryCommand { get; set; }

        public MainViewModel()
        {
            ProductCount = 1;
            Product = new Product()
            {
                Name = string.Empty,
                Price = string.Empty,
                Volume = string.Empty,
                ImagePath = "../Assets/Images/x.jpg"
            };

            Products = new List<Product>
            {
                new Product
                {
                    Name = "Coca-Cola",
                    Price = "2 $",
                    Volume = "330 ml",
                    ImagePath = "../Assets/Images/coca-cola.jpg"
                },
                new Product
                {
                    Name = "Fanta",
                    Price = "3 $",
                    Volume = "330 ml",
                    ImagePath = "../Assets/Images/fanta.jpg"
                },
                new Product
                {
                    Name = "Pepsi",
                    Price = "2.5 $",
                    Volume = "330 ml",
                    ImagePath = "../Assets/Images/pepsi.jpg"
                }
            };

            IncreaseCommand = new RelayCommand((e) =>
            {
                ProductCount++;
            });

            DecreaseCommand = new RelayCommand((e) =>
            {
                if (ProductCount > 1) ProductCount--;
            });

            SelectedItemChangedCommand = new RelayCommand((e) =>
            {
                Product = SelectedProduct;
            });

            ResetCommand = new RelayCommand((e) =>
            {
                Product temp = new Product()
                {
                    Name = string.Empty,
                    Price = string.Empty,
                    Volume = string.Empty,
                    ImagePath = "../Assets/Images/x.jpg"
                };
                Product = temp;
                ProductCount = 1;
            });

            BuyCommand = new RelayCommand((e) =>
            {
                if(!Product.Name.Equals(string.Empty))
                {
                    ProductHistory productHistory = new ProductHistory()
                    {
                        Date = $"{ DateTime.Now.ToLongDateString() } { DateTime.Now.ToLongTimeString() }",
                        Name = Product.Name,
                        Price = Product.Price,
                        Volume = Product.Volume,
                        Count = ProductCount,
                        Total = (decimal.Parse(Product.Price.Split()[0]) * ProductCount).ToString()
                    };
                    ProductHistories.Add(productHistory);
                    Helper.File.PrintVaucher(productHistory);
                    MessageBox.Show("Your order has been successfully completed !", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    SelectedProduct = null;
                    ResetCommand.Execute(e);
                }
                else
                {
                    MessageBox.Show("You must select a product !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            ShowHistoryCommand = new RelayCommand((e) =>
            {
                HistoryWindow historyWindow = new HistoryWindow(ProductHistories);
                historyWindow.ShowDialog();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

