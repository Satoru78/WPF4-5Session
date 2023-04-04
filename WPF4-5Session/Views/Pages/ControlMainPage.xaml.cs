using Microsoft.Win32;
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
    /// Логика взаимодействия для ControlMainPage.xaml
    /// </summary>
    public partial class ControlMainPage : Page
    {
        public User User { get; set; }
        public List<Gender> Genders { get; set; }
        public ControlMainPage(User user)
        {
            InitializeComponent();
            Genders = Data.db.Gender.ToList();
            User = user;
            this.DataContext = this;
        }
        OpenFileDialog open = new OpenFileDialog();
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            open.Filter = "Image (*.jpeg; *.png; *.jpg;) | *.jpeg;* .png; *.jpg";
            if (open.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(open.FileName));
                Img.Source = image;

            }
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
                MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch
            {
                MessageBox.Show("Произошла неизвестная ошибка , проверьте заполнены ли все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
       }
    }
}
