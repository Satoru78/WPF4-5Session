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
using WPF4_5Session.Context;
using WPF4_5Session.Model;

namespace WPF4_5Session.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Window
    {
        public User User { get; set; }
        public List<UserType> UserTypes { get; set; }
        public Avtorization()
        {
            InitializeComponent();
            UserTypes = Data.db.UserType.ToList();
            this.DataContext = this;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbPassword.Text == "" && txbLogin.Text == "" && txbSecretWord.Text == "")
                {
                    throw new Exception("Заполните все поля!");
                }
                else
                {
                    var currentUser = Data.db.User.FirstOrDefault(item => item.Login == txbLogin.Text && item.Password == txbPassword.Text);
                    if (currentUser != null && cmdTypeUser.Text == cmdTypeUser.Text)
                    {
                        switch (currentUser.IDUserType)
                        {
                            case 1:
                                DostupControl dostupControl = new DostupControl(currentUser);
                                dostupControl.ShowDialog();
                                break;
                            case 2:
                                SecurityManagment securityManagement = new SecurityManagment(currentUser);
                                securityManagement.ShowDialog();
                                break;

                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
