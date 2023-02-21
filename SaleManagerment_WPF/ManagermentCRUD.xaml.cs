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

        private void bt_SearchProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? id = int.Parse(searchId.Text);
                string name = searchName.Text;
                int? unitPrice = int.Parse(searchUnitPrice.Text);
                int? unitStocks = int.Parse(searchUnitInStocks.Text);
                dtgProducts.ItemsSource = _productRepository.SearchProduct(id, name, unitPrice, unitStocks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void bt_MemberManagerment_Click(object sender, RoutedEventArgs e)
        {
            MemberManagerment member = new MemberManagerment();
            member.Show();
            this.Hide();
        }

        private void bt_OrderMangerment_Click(object sender, RoutedEventArgs e)
        {
            OrderManagerment order = new OrderManagerment();
            order.Show();
            this.Hide();
        }
    }
}
