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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private User selectedUser;
        public AdminPage()
        {
            InitializeComponent();

            UserGrid.ItemsSource = DBConnect.entities.User.ToList();
        }

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = (User)UserGrid.SelectedItem;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null)
            {
                AdminEditPage editPage = new AdminEditPage(selectedUser);
                FrameApp.frmObj.Navigate(editPage);
            }

        }

        private void GoBackIWantToBeMonkey_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
