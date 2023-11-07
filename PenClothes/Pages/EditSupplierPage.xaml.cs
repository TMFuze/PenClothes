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
    /// Логика взаимодействия для EditSupplierPage.xaml
    /// </summary>
    public partial class EditSupplierPage : Page
    {
        private Supplier supplier;
        public EditSupplierPage(Supplier selectedSupplier)
        {
            InitializeComponent();

            this.supplier = selectedSupplier;
            // Заполните элементы формы значениями из supplier
            if (supplier != null)
            {
                TxbName.Text = supplier.Title;
                TxbINN.Text = supplier.INN;
                DatePicker.SelectedDate = supplier.StartDate;
                TxbQuality.Text = supplier.QualityRating.ToString();
                TxbType.Text = supplier.SupplierType;
            }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (supplier != null)
            {
                supplier.Title = TxbName.Text;
                supplier.INN = TxbINN.Text;
                supplier.StartDate = DatePicker.DisplayDate;
                supplier.QualityRating = int.Parse(TxbQuality.Text);
                supplier.SupplierType = TxbType.Text;

                DBConnect.entities.SaveChanges();
                FrameApp.frmObj.Navigate(new SupplierList());
            }
        }

        private void GoBackIWantToBeMonkey_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
