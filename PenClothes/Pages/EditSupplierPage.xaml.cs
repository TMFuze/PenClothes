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
        private Supplier selectedSupplier;
        public EditSupplierPage(Supplier selectedSupplier)
        {
            InitializeComponent();

            TxbName.Text = selectedSupplier.Title;
            TxbINN.Text = selectedSupplier.INN;
            DatePicker.SelectedDate = selectedSupplier.StartDate;
            TxbQuality.Text = selectedSupplier.QualityRating.ToString();
            TxbType.Text = selectedSupplier.SupplierType;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Получите данные из элементов управления
            string newName = TxbName.Text;
            string newINN = TxbINN.Text;
            DateTime newStartDate = DatePicker.SelectedDate ?? DateTime.MinValue; // Обработка null значения
            int newQualityRating = int.Parse(TxbQuality.Text);
            string newSupplierType = TxbType.Text;
            if (selectedSupplier == null)
            {
                selectedSupplier = new Supplier();
            }
            else
            {
                // Обновите выбранного поставщика
                selectedSupplier.Title = newName;
                selectedSupplier.INN = newINN;
                selectedSupplier.StartDate = newStartDate;
                selectedSupplier.QualityRating = newQualityRating;
                selectedSupplier.SupplierType = newSupplierType;
                
                DBConnect.entities.SaveChanges();
            }
            try
            {
                // Сохраните изменения в базе данных
               

                MessageBox.Show("Изменения сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameApp.frmObj.Navigate(new SupplierList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBackIWantToBeMonkey_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
