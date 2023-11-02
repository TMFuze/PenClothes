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
    /// Логика взаимодействия для AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Page
    {
        public AddSupplier()
        {
            InitializeComponent();

            TxbINN.MaxLength = 12;
            TxbName.MaxLength = 150;
            TxbType.MaxLength = 20;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DBConnect.entities.Supplier.Count(x => x.Title == TxbName.Text) > 0)
            {
                MessageBox.Show("Такой поставщик уже есть!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    Supplier supplierObj = new Supplier()
                    {
                        Title = TxbName.Text,
                        INN = TxbINN.Text,
                        StartDate = Convert.ToDateTime(DatePicker.SelectedDate),
                        QualityRating = Convert.ToInt32(TxbQuality.Text),
                        SupplierType = TxbType.Text
                    };

                    DBConnect.entities.Supplier.Add(supplierObj);
                    DBConnect.entities.SaveChanges();

                    MessageBox.Show("Поставщик добавлен",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                "Критический сбой работы приложения",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                }
            }
        }

        private void GoBackIWantToBeMonkey_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
