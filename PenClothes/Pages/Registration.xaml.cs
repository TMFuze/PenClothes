using PenClothes.AppFiles;
using PenClothes.DBEnt;
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

namespace PenClothes.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();

            RoleSelect.SelectedValuePath = "Id";
            RoleSelect.DisplayMemberPath = "Name";
            RoleSelect.ItemsSource = DBConnect.entities.Role.ToList();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User userObj = new User()
                {
                    IdRole = Convert.ToInt32(RoleSelect.SelectedValue),
                    Name = TxbName.Text,
                    Password = PsbPass.Password,
                    Login = TxbLog.Text,
                };


                if (DBConnect.entities.User.Count(x => x.Login == userObj.Login && x.Password == userObj.Password) > 0)
                {
                    MessageBox.Show("Такой пользователь уже существует",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                    return;

                }
                else if (TxbLog.Text == null | TxbLog.Text.Trim() == "" |
                TxbName.Text == null | TxbName.Text.Trim() == "" |
                PsbPass.Password == null | PsbPass.Password.Trim() == "" |
                RoleSelect.SelectedItem == null)
                
                {
                    MessageBox.Show("Заполните все поля!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {

                    DBConnect.entities.User.Add(userObj);
                    DBConnect.entities.SaveChanges();

                    MessageBox.Show("Вы успешно зарегестрировались!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                    FrameApp.frmObj.Navigate(new Auth());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                "Критический сбой работы приложения",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
