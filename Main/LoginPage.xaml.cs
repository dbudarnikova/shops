using Shop_stationery.ApplicationData;
using Shop_stationery.MainWind;
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

namespace Shop_stationery.Main
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model0db.Users.FirstOrDefault(x => x.login == wrLogin.Text && x.Password == wrPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + userObj.Name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            FrameApp.frameMain.Navigate(new PageMainW());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Кассир " + userObj.Name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            FrameApp.frameMain.Navigate(new PageMainW());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnRegIn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameMain.Navigate(new RegistrationPage());
        }
    }
}
