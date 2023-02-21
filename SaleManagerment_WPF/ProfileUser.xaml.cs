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
    /// Interaction logic for ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Window
    {
        private readonly IMemberRepository _memberRepsitory;
        private readonly IOrderRepository _orderRepsitory;
        private readonly Member CurrentUser;
        public ProfileUser(IMemberRepository memberRepository, 
            IOrderRepository orderRepository, 
            Member member)
        {
            _memberRepsitory = memberRepository;
            _orderRepsitory = orderRepository;
            CurrentUser = member;
            InitializeComponent();
        }

        private void btUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            string companyName = tbComName.Text;
            string country = tbCountry.Text;
            string city = tbCity.Text;
            try
            {
                var userUpdate = new Member()
                {
                    MemberId = CurrentUser.MemberId,
                    Email = email,
                    Password = password,
                    CompanyName = companyName,
                    Country = country,
                    City = city,
                };
                if (_memberRepsitory.IsEmailExist(email, CurrentUser.MemberId))
                {
                    MessageBox.Show("Email is already exits!", "Email exist", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (_memberRepsitory.UpdateMember(userUpdate))
                    {
                        MessageBox.Show("Update sucessfully!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update fail!", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Window_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                tbEmail.Text = CurrentUser.Email.ToString();
                tbPassword.Text = CurrentUser.Password.ToString();
                tbComName.Text = CurrentUser.CompanyName.ToString();
                tbCountry.Text = CurrentUser.Country.ToString();
                tbCity.Text = CurrentUser.City.ToString();
                var listOrders = _orderRepsitory.GetByMemberId(CurrentUser.MemberId);
                if (listOrders != null && listOrders.Any()) 
                    dtgOrders.ItemsSource = listOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
