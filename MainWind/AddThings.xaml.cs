using Shop_stationery.ApplicationData;
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
    /// Логика взаимодействия для AddThings.xaml
    /// </summary>
    public partial class AddThings : Page
    {
        public AddThings()
        {
            InitializeComponent();
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            FrameApp.frameMain.Navigate(new PageMainW());
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            using (var context = new Shop())
            {
                string typeName = Название.Text;
                string decorRegNum = Цена.Text;
                string decorYear = Производитель.Text;
                string decorColor = Количество.Text;

                context.Shop_bd.Add(new Shop_bd
                {
                    Название = typeName,
                    Цена = decorRegNum,
                    Производитель = decorYear,
                    Количество = decorColor,
                });
                int result = context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Добавлено!");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так. Попробуйте еще раз.");
                }
            }
        }
    }
}
