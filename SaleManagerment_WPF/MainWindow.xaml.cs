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
        IMemberRepository _memberRepository;
        public MainWindow(IMemberRepository memberRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
        }

        private void dtbMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void LoadData(object sender, RoutedEventArgs e)
        {
            try
            {
                dtbMembers.ItemsSource = _memberRepository.GetAllMembers();
                //App app = new App();
                var user = App.Admin.Username;
                var pass = App.Admin.Password;
                if (user != null && pass != null)
                {
                    lbPassword.Content = pass;
                    lbUserName.Content = user;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
