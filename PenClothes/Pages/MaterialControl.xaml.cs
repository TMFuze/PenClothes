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
    /// Логика взаимодействия для MaterialControl.xaml
    /// </summary>
    public partial class MaterialControl : Page
    {
        public MaterialControl()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MaterialList());
        }

        private void AddMaterial_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddMaterial());
        }
    }
}
