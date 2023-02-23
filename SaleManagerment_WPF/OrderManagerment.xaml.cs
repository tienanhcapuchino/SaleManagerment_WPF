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
    /// Interaction logic for OrderManagerment.xaml
    /// </summary>
    public partial class OrderManagerment : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly string _username;
        public OrderManagerment(IMemberRepository memberRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            string currentUser)
        {
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _username = currentUser;
            InitializeComponent();
        }
        private void Load_Order(object sender, RoutedEventArgs e)
        {
            try
            {
                var listOrders = _orderRepository.GetAllOrders();
                lbWelcome.Content = "Welcome Admin " + _username;
                if (listOrders.Any())
                    dtgOrders.ItemsSource = listOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_ProducrManagerment_Click(object sender, RoutedEventArgs e)
        {
            ManagermentCRUD product = new ManagermentCRUD(_memberRepository, _orderRepository, _productRepository, _username);
            product.Show();
            this.Hide();
        }

        private void bt_MemberMangerment_Click(object sender, RoutedEventArgs e)
        {
            MemberManagerment member = new MemberManagerment(_memberRepository, _orderRepository, _productRepository, _username);
            member.Show();
            this.Hide();
        }

        private void bt_AddOrd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order()
                {
                    OrderDate = Convert.ToDateTime(dpOrder.Text),
                    MemberId = Convert.ToInt32(tbMemberId.Text),
                    Freight = Convert.ToDecimal(tbFreight.Text),
                    ShippedDate = Convert.ToDateTime(dpShip.Text),
                    RequiredDate = Convert.ToDateTime(dpRequire.Text),
                };
                if (_orderRepository.CreateOrder(order))
                {
                    MessageBox.Show("add successfully!");
                    Load_Order(sender, e);
                }
                else
                {
                    MessageBox.Show("add fail!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_UpdateOrd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order()
                {
                    OrderId = Convert.ToInt32(tbOrderId.Text),
                    OrderDate = Convert.ToDateTime(dpOrder.Text),
                    MemberId = Convert.ToInt32(tbMemberId.Text),
                    Freight = Convert.ToDecimal(tbFreight.Text),
                    ShippedDate = Convert.ToDateTime(dpShip.Text),
                    RequiredDate = Convert.ToDateTime(dpRequire.Text),
                };
                if (_orderRepository.UpdateOder(order))
                {
                    MessageBox.Show("update successfully!");
                    Load_Order(sender, e);
                }
                else
                {
                    MessageBox.Show("update fail!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_DeleteOrd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int orId = Convert.ToInt32(tbOrderId.Text);
                if (_orderRepository.DeleteOrder(orId))
                {
                    MessageBox.Show("delete successfully!");
                    Load_Order(sender, e);
                }
                else
                {
                    MessageBox.Show("delete fail!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Order or in  dtgOrders.SelectedItems)
            {
                tbOrderId.Text = or.OrderId.ToString();
                tbMemberId.Text = or.MemberId.ToString();
                dpOrder.Text = or.OrderDate.ToString();
                dpRequire.Text = or.RequiredDate.ToString();
                dpShip.Text = or.ShippedDate.ToString();
                tbFreight.Text = or.Freight.ToString();
            }
        }
    }
}
