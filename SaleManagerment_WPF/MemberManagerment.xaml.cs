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
    }
}
