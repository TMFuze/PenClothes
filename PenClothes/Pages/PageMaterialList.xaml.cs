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
    /// Логика взаимодействия для PageMaterialList.xaml
    /// </summary>
    public partial class PageMaterialList : Page
    {
        private List<Material> allItems;

        public PageMaterialList()
        {
            InitializeComponent();

            allItems = DBConnect.entities.Material.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaterialList.ItemsSource = DBConnect.entities.Material.Where(x => x.Title.Contains(TxbSearch.Text)).Take(15).ToList();
                ResultTxb.Text = MaterialList.Items.Count + "/" + DBConnect.entities.Material.Where(x => x.Title.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch(Exception ex)
            {
                throw; 
            }
        }

        

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSort.SelectedIndex == 0)
            {
                List<Material> sortMaterials = allItems.OrderBy(x => x.Title).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<Material> sortMaterials = allItems.OrderByDescending(x => x.Title).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 2)
            {
                List<Material> sortMaterials = allItems.OrderBy(x => x.MinCount).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 3)
            {
                List<Material> sortMaterials = allItems.OrderByDescending(x => x.MinCount).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 4)
            {
                List<Material> sortMaterials = allItems.OrderBy(x => x.Cost).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 5)
            {
                List<Material> sortMaterials = allItems.OrderByDescending(x => x.Cost).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as MaterialType;
            var items = (select != null) ? allItems.Where(x => x.MaterialTypeID == select.ID) : allItems;
            MaterialList.ItemsSource = items;
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MaterialList.SelectedItems.Count >= 1)
            {
                BtnChange.Visibility = Visibility.Visible;
            }
            else
            {
                BtnChange.Visibility = Visibility.Hidden;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CmbFilter.ItemsSource = DBConnect.entities.MaterialType.ToList();
                CmbFilter.DisplayMemberPath = "Title";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;

                MaterialList.ItemsSource = DBConnect.entities.Material.Take(100).ToList();
                ResultTxb.Text = MaterialList.Items.Count + "/" + DBConnect.entities.Material.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Что-то пошло не так!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
            }
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBackIWantToBeMonkey_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
