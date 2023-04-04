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
    /// Логика взаимодействия для MandatEditPage.xaml
    /// </summary>
    public partial class MandatEditPage : Page
    {
        public List<DataAddPermission> DataAddPermissions { get; set; }
        public List<ReportPermission> ReportPermissions { get; set; }
        public List<DataViewPermission> DataViewPermissions { get; set; }
        public User User { get; set; }
        public MandatEditPage(User user)
        {
            InitializeComponent();
            User = user;
            this.DataContext = this;
            DataViewPermissions = Data.db.DataViewPermission.ToList();
            DataAddPermissions = Data.db.DataAddPermission.ToList();
            ReportPermissions = Data.db.ReportPermission.ToList();
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
