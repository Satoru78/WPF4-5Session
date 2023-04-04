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
using WPF4_5Session.Context;
using WPF4_5Session.Model;

namespace WPF4_5Session.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для VerifyDataPage.xaml
    /// </summary>
    public partial class VerifyDataPage : Page
    {
        public UserType UserType { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; }
        public Verify Verify { get; set; }
        public VerifyDataPage(User user)
        {
            InitializeComponent();
            User = user;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Users = Data.db.User.ToList();
            UserDataGrid.ItemsSource = Users;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = UserDataGrid.SelectedItem as User;
                if (selectedItem != null)
                {
                    NavigationService.Navigate(new VerifyEditPage(selectedItem));
                }
                else
                {
                    throw new Exception("Пожалуйста, выберите объект из списка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
