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
    /// Interaction logic for MemberManagerment.xaml
    /// </summary>
    public partial class MemberManagerment : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly string _username;
        public MemberManagerment(IMemberRepository memberRepository,
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

        private void bt_MemberManagerment_Click(object sender, RoutedEventArgs e)
        {
            ManagermentCRUD product = new ManagermentCRUD(_memberRepository, _orderRepository, _productRepository, _username);
            product.Show();
            this.Hide();
        }

        private void bt_OrderMangerment_Click(object sender, RoutedEventArgs e)
        {
            OrderManagerment order = new OrderManagerment(_memberRepository, _orderRepository, _productRepository, _username);
            order.Show();
            this.Hide();
        }

        private void bt_AddMem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member mem = new Member()
                {
                    Email = tbEmail.Text,
                    City = tbCity.Text,
                    CompanyName = tbCompany.Text,
                    Password = tbPassword.Text,
                    Country = tbCountry.Text,
                };
                if (_memberRepository.CreateMember(mem))
                {
                    MessageBox.Show("add successfully!");
                    Load_Members(sender, e);
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
        private void Load_Members(object sender, RoutedEventArgs e)
        {
            var list = _memberRepository.GetAllMembers();
            lbWelcome.Content = "Welcome Admin " + _username;
            if (list.Any())
                dtgMember.ItemsSource = list;
        }

        private void bt_UpdateMem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member mem = new Member()
                {
                    Email = tbEmail.Text,
                    City = tbCity.Text,
                    CompanyName = tbCompany.Text,
                    MemberId = int.Parse(tbId.Text),
                    Password = tbPassword.Text,
                    Country = tbCountry.Text,
                };
                if (_memberRepository.UpdateMember(mem))
                {
                    MessageBox.Show("update successfully!");
                    Load_Members(sender, e);
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

        private void bt_DeleteMem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbId.Text != null)
                {
                    if (_memberRepository.DeleteUser(int.Parse(tbId.Text)))
                    {
                        MessageBox.Show("Delete successfully!");
                        Load_Members(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete fail!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtgMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Member mem in dtgMember.SelectedItems)
            {
                tbId.Text = mem.MemberId.ToString();
                tbEmail.Text = mem.Email;
                tbCountry.Text = mem.Country;
                tbCity.Text = mem.City;
                tbCountry.Text = mem.Country;
                tbPassword.Text = mem.Password;
            }
        }
    }
}
