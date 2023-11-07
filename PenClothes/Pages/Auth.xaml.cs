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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        
        public Auth()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        void ShowWelcomeMessageAndNavigate(string roleName, string userName)
        {
            string message = "Здравствуйте " + roleName + " " + userName + "!";
            MessageBox.Show(message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            WellcomePage welcomePage = new WellcomePage(userName);
            FrameApp.frmObj.Navigate(welcomePage);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbLog.Text == null ||
                    TxbLog.Text == "" ||
                    PsbPass.Password == null ||
                    PsbPass.Password == "")
                {
                    MessageBox.Show("Заполните все строки!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                }
                else
                {
                    var userObj = DBConnect.entities.User.FirstOrDefault(x => x.Login == TxbLog.Text && x.Password == PsbPass.Password);
                    
                    if (userObj == null)
                    {
                        MessageBox.Show("Такой пользователь не найден",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                        
                    }
                    else
                    {






                        switch (userObj.IdRole)
                        {
                            case 1:
                                MessageBox.Show("Здравствуйте кладовщик " + userObj.Name + "!",
                                   "Уведомление",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);

                                // Создайте объект UserMenu и перейдите на эту страницу
                                UserMenu userMenu = new UserMenu();
                                FrameApp.frmObj.Navigate(userMenu);
                                break;
                            case 2:
                                ShowWelcomeMessageAndNavigate("Оператор", userObj.Name);
                                break;
                            case 3:
                                ShowWelcomeMessageAndNavigate("Агент", userObj.Name);
                                break;
                            case 4:
                                ShowWelcomeMessageAndNavigate("Менеджер", userObj.Name);
                                break;
                            case 5:
                                MessageBox.Show("Здравствуйте крадовик " + userObj.Name + "!",
                                   "Уведомление",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);

                                
                                
                                FrameApp.frmObj.Navigate(new AdminPage());
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой в работе приложения: " + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);

            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.Registration());
        }
    }
}
