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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaleManagerment_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public MainWindow(IMemberRepository memberRepository, 
            IOrderRepository orderRepository, 
            IProductRepository productRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        private void dtbMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void LoadData(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //dtbMembers.ItemsSource = _memberRepository.GetAllMembers();
            //App app = new App();
            //var user = App.Admin.Username;
            //var pass = App.Admin.Password;
            //if (user != null && pass != null)
            //{
            //    lbPassword.Content = pass;
            //    lbUserName.Content = user;
            //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Password;
            UserDto us = new UserDto()
            {
                Username = username,
                Password = password
            };
            Member mem = _memberRepository.FindByEmail(username);
            if (_memberRepository.UserLogged(us))
            {
                ProfileUser profile = new ProfileUser(_memberRepository, _orderRepository, mem);
                profile.Show();
                this.Hide();
            }
            else if (App.Admin.Username == username && App.Admin.Password == password)
            {
                ManagermentCRUD manager = new ManagermentCRUD(_memberRepository, _orderRepository, _productRepository, username);
                manager.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User or password is incorrect! Please try again!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
