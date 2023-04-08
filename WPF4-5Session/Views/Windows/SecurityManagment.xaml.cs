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
using WPF4_5Session.Model;
using WPF4_5Session.Views.Pages;

namespace WPF4_5Session.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SecurityManagment.xaml
    /// </summary>
    public partial class SecurityManagment : Window
    {
        public User User { get; set; }  
        public UserType UserType { get; set; }
        public SecurityManagment(User user)
        {
            InitializeComponent();
            SecFrame.Navigate(new VerifyDataPage(User));
            this.User = user;
            tblNameUser.Text = $"Пользователь: {user.FisrtName} {user.LastName} {user.Patronymic}";
        }
        MandatDataPage mandat = new MandatDataPage(new User());
        VerifyDataPage verify = new VerifyDataPage(new User());
        private void mandatBtn_Click(object sender, RoutedEventArgs e)
        {
            SecFrame.Navigate(new MandatDataPage(User));
            if (mandat.Visibility == Visibility.Visible)
            {
                mandatBtn.Background = Brushes.SkyBlue;
                verifyBtn.Background = Brushes.Silver;
            }
        }

        private void verifyBtn_Click(object sender, RoutedEventArgs e)
        {
            SecFrame.Navigate(new VerifyDataPage(new Model.User()));
            if (verify.Visibility == Visibility.Visible)
            {
                verifyBtn.Background = Brushes.SkyBlue;
                mandatBtn.Background = Brushes.Silver;
            }
        }
    }
}
