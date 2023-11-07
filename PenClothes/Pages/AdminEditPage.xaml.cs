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
    /// Логика взаимодействия для AdminEditPage.xaml
    /// </summary>
    public partial class AdminEditPage : Page
    {

        private User user;

        public AdminEditPage(User selectedUser)
        {
            InitializeComponent();

            CmbRole.SelectedValuePath = "Id";
            CmbRole.DisplayMemberPath = "Name";
            CmbRole.ItemsSource = DBConnect.entities.Role.ToList();

            this.user = selectedUser;
            // Заполните элементы формы значениями из supplier
            if (user != null)
            {
                TxbName.Text = user.Name;
                TxbLog.Text = user.Login;
                TxbPass.Text = user.Password;
                CmbRole.SelectedItem = user.Role;
                
            }
        }

        private void GoBackIWantToBeMonkey_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                user.Name = TxbName.Text;
                user.Login = TxbLog.Text;
                user.Password = TxbPass.Text;
                user.Role = (Role)CmbRole.SelectedItem;

                DBConnect.entities.SaveChanges();
                FrameApp.frmObj.Navigate(new AdminPage());
            }
        }
    }
}
