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
    /// Логика взаимодействия для VerifyEditPage.xaml
    /// </summary>
    public partial class VerifyEditPage : Page
    {
        public User User { get; set; }
        public List<Verify> Verifies { get; set; }
        public VerifyEditPage(User user)
        {
            InitializeComponent();
            User = user;
            this.DataContext = this;
            Verifies = Data.db.Verify.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (User.ID == 0)
                {
                    Data.db.User.Add(User);
                }
                Data.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
