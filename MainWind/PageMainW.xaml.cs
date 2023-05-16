
using Shop_stationery.ApplicationData;
using Shop_stationery.Model;
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


namespace Shop_stationery.MainWind
{
    /// <summary>
    /// Логика взаимодействия для PageMainW.xaml
    /// </summary>
    public partial class PageMainW : Page
    {
        public PageMainW()
        {
            InitializeComponent();
            Loaded += PageAddCar_Loaded;
        }

        private void PageAddCar_Loaded(object sender, RoutedEventArgs e)
        {
            Data.ItemsSource = AppData.db.Shop_bd.ToList();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Изменить данные?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.db.SaveChanges();
                Data.ItemsSource = AppData.db.Shop_bd.ToList();
                MessageBox.Show("Изменено!");
            }
            AppData.db.SaveChanges();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                if (MessageBox.Show("Удалить?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var CurrentClient = Data.SelectedItem as Shop_bd;
                    AppData.db.Shop_bd.Remove(CurrentClient);
                    AppData.db.SaveChanges();
                    Data.ItemsSource = AppData.db.Shop_bd.ToList();
                    MessageBox.Show("Успешно!");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameApp.frameMain.Navigate(new AddThings());
        }

        private void Data_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
