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
    /// Логика взаимодействия для EditMaterialPage.xaml
    /// </summary>
    public partial class EditMaterialPage : Page
    {
        private Material material;
        public EditMaterialPage(Material selectedMaterial)
        {
            InitializeComponent();

            CmbType.SelectedValuePath = "Id";
            CmbType.DisplayMemberPath = "Title";
            CmbType.ItemsSource = DBConnect.entities.MaterialType.ToList();

            this.material = selectedMaterial;
            // Заполните элементы формы значениями из supplier
            if (material != null)
            {
                TxbTitle.Text = material.Title;
                CmbType.SelectedItem = material.MaterialType;
                TxbCountInStock.Text = material.CountInStock?.ToString();
                TxbUnit.Text = material.Unit;
                TxbCountInPack.Text = material.CountInPack.ToString();
                TxbMinCount.Text = material.MinCount.ToString();
                TxbCost.Text = material.Cost.ToString();
                TxbDescription.Text = material.Description;
                var imageSource = new BitmapImage(new Uri(material.Image, UriKind.RelativeOrAbsolute));
                FotoMaterial.Source = imageSource;


            }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (material != null)
            {
                material.Title = TxbTitle.Text;
                material.MaterialType = (MaterialType)CmbType.SelectedItem;
                if (double.TryParse(TxbCountInStock.Text, out double countInStock))
                {
                    material.CountInStock = countInStock;
                }
                material.Unit = TxbUnit.Text;
                material.CountInPack = int.Parse(TxbCountInPack.Text);
                material.MinCount = int.Parse(TxbMinCount.Text);
                if (int.TryParse(TxbCost.Text, out int cost))
                {
                    material.Cost = cost;
                }
                material.Description = TxbDescription.Text;
                if (FotoMaterial.Source is BitmapImage bitmapImage)
                {
                    material.Image = bitmapImage.UriSource.AbsolutePath;
                }
                DBConnect.entities.SaveChanges();
                FrameApp.frmObj.Navigate(new MaterialList());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
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
