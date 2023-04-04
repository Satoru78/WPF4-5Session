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
using WPF4_5Session.Model;
using WPF4_5Session.Views.Pages;

namespace WPF4_5Session
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class DostupControl : Window
    {
        public User User { get; set; }
        public UserType UserType { get; set; }
        public DostupControl(User user)
        {
            InitializeComponent();
            MainFrame.Navigate(new ControlMainPage(new User()));
            this.User = user;
            tblNameUser.Text = $"Пользователь: {user.FisrtName} {user.LastName} {user.Patronymic}";
        }
    }
}
