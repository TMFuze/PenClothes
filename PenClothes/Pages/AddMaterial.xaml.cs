using Microsoft.Win32;
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
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddMaterial : Page
    {
        public AddMaterial()
        {
            InitializeComponent();

            CmbType.SelectedValuePath = "Id";
            CmbType.DisplayMemberPath = "Title";
            CmbType.ItemsSource = DBConnect.entities.MaterialType.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbTitle.Text == null)
            {
                MessageBox.Show("Заполните наименование!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbCost.Text == null)
            {
                MessageBox.Show("Заполните цену!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbUnit.Text == null)
            {
                MessageBox.Show("Заполните единицу измерения!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbCountInPack.Text == null)
            {
                MessageBox.Show("Заполните количество в упаковке!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbMinCount.Text == null)
            {
                MessageBox.Show("Заполните минимальное количество на складе!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                if (DBConnect.entities.Material.Count(x => x.Title == TxbTitle.Text) > 0)
                {
                    MessageBox.Show("Такой материал уже есть!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    return;
                }
                else
                {
                    try
                    {
                        Material materialObj = new Material()
                        {
                            Title = TxbTitle.Text,
                            CountInPack = Convert.ToInt32(TxbCountInPack.Text),
                            Unit = TxbUnit.Text,
                            CountInStock = Convert.ToInt32(TxbCountInStock.Text),
                            MinCount = Convert.ToInt32(TxbMinCount.Text),
                            Description = TxbDescription.Text,
                            Cost = Convert.ToInt32(TxbCost.Text),
                            Image = TxbUrl.Text,
                            MaterialTypeID = CmbType.SelectedIndex + 1
                        };

                        DBConnect.entities.Material.Add(materialObj);
                        DBConnect.entities.SaveChanges();

                        MessageBox.Show("Материал добавлен",
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
        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите фото";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                FotoMaterial.Source = new BitmapImage(new Uri(op.FileName));
                TxbUrl.Text = op.FileName;
            }
        }
    }
}
