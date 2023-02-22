using BusinessObject.Models;
using DataAcess.Repository;
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
using System.Windows.Shapes;

namespace SaleManagerment_WPF
{
    /// <summary>
    /// Interaction logic for ManagermentCRUD.xaml
    /// </summary>
    public partial class ManagermentCRUD : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly string _username;
        public ManagermentCRUD(IMemberRepository memberRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            string member)
        {
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _username = member;
            InitializeComponent();
        }
        private void Manager_Window_Load(object sender, EventArgs e)
        {
            lbWelcome.Content = "Welcome Admin: " + _username;
            dtgProducts.ItemsSource = _productRepository.GetAllProducts();
        }

        private void bt_SearchId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(searchId.Text);
                if (string.IsNullOrEmpty(searchId.Text))
                {
                    MessageBox.Show("Enter id to search!");
                }
                else dtgProducts.ItemsSource = _productRepository.SearchProductById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_MemberManagerment_Click(object sender, RoutedEventArgs e)
        {
            MemberManagerment member = new MemberManagerment(_memberRepository, _orderRepository, _productRepository, _username);
            member.Show();
            this.Hide();
        }

        private void bt_OrderMangerment_Click(object sender, RoutedEventArgs e)
        {
            OrderManagerment order = new OrderManagerment(_memberRepository, _orderRepository, _productRepository, _username);
            order.Show();
            this.Hide();
        }

        private void bt_SearchName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = searchName.Text;
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Enter name to search!");
                }
                else dtgProducts.ItemsSource = _productRepository.SearchProductByName(name.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_SearchPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int unitPrice = int.Parse(searchUnitPrice.Text);
                if (string.IsNullOrEmpty(searchUnitPrice.Text))
                {
                    MessageBox.Show("Enter price to search!");
                }
                else dtgProducts.ItemsSource = _productRepository.SearchProductByPrice(unitPrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_SearchStock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int unitStocks = int.Parse(searchUnitInStocks.Text);
                if (string.IsNullOrEmpty(searchUnitInStocks.Text))
                {
                    MessageBox.Show("Enter stock to search!");
                }
                else dtgProducts.ItemsSource = _productRepository.SearchProductByStocks(unitStocks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_AddPro_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Product pr = new Product()
                {
                    ProductName = searchName.Text,
                    CategoryId = int.Parse(tbCate.Text),
                    UnitPrice = int.Parse(searchUnitPrice.Text),
                    UnitsInStock = int.Parse(searchUnitInStocks.Text),
                    Weight = tbWeight.Text
                };
                if (_productRepository.AddNewProduct(pr))
                {
                    Manager_Window_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Cannot add, check value again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_UpdatePro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product pr = new Product()
                {
                    ProductId = int.Parse(searchId.Text),
                    ProductName = searchName.Text,
                    CategoryId = int.Parse(tbCate.Text),
                    UnitPrice = decimal.Parse(searchUnitPrice.Text),
                    UnitsInStock = int.Parse(searchUnitInStocks.Text),
                    Weight = tbWeight.Text
                };
                if (_productRepository.UpdateProduct(pr))
                {
                    MessageBox.Show("Update successfully!");
                    Manager_Window_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Cannot add, check value again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_DeletePro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Product pr in dtgProducts.SelectedItems)
                {
                    if (_productRepository.DeleteProduct(pr.ProductId))
                    {
                        MessageBox.Show("Delete successfully!");
                        Manager_Window_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Product pr in dtgProducts.SelectedItems)
            {
                searchId.Visibility = Visibility.Hidden;
                searchId.Text = pr.ProductId.ToString();
                searchName.Text = pr.ProductName;
                searchUnitPrice.Text = pr.UnitPrice.ToString();
                searchUnitInStocks.Text = pr.UnitsInStock.ToString();
                tbCate.Text = pr.UnitsInStock.ToString();
                tbWeight.Text = pr.UnitsInStock.ToString();
            }
        }
    }
}
