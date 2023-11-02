using PenClothes.AppFiles;
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
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Page
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void ChekListMaterials_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageMaterialList());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void SupplierList_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new SupplierList());
        }
    }
}
