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
    /// Логика взаимодействия для SupplierList.xaml
    /// </summary>
    public partial class SupplierList : Page
    {
        public SupplierList()
        {
            InitializeComponent();

            SupplierGrid.ItemsSource = DBConnect.entities.Supplier.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var fileForEdit = SupplierGrid.SelectedItems.Cast<Supplier>().ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var filesForRemoving = SupplierGrid.SelectedItems.Cast<Supplier>().ToList();
            try
            {
                var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаление выбранных файлов из базы данных
                    DBConnect.entities.Supplier.RemoveRange(filesForRemoving);
                    DBConnect.entities.SaveChanges();
                    MessageBox.Show("Данные удалены.");

                    SupplierGrid.ItemsSource = DBConnect.entities.Supplier.ToList();

                    
                }
                else
                {
                    SupplierGrid.ItemsSource = DBConnect.entities.Supplier.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
