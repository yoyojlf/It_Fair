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
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using MahApps.Metro.Controls.Dialogs;
using Negocio;

namespace Diseño
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CargaTipo();
        }

        private void CargaTipo()
        {
            CbTipo.ItemsSource = Enum.GetValues(typeof(TipoCombo));
        }
        private void TextBox(object sender, TextChangedEventArgs e)
        {

        }
        private void Tile_Import(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            BitmapImage b = new BitmapImage();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = "C:\\";

            if (openFileDialog.ShowDialog() == true)

            {
                b.BeginInit();

                b.UriSource = new Uri(openFileDialog.FileName);

                b.EndInit();
                Images.Stretch = Stretch.Fill;
                Images.Source = b;
            }

            else
            {



            }

        }


        private async void Tile_SaveAsync(object sender, RoutedEventArgs e)
        {


            if (await this.ShowMessageAsync("Warning Message", "You are saving a Data file, Are you sure?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
            {
                await this.ShowMessageAsync("Information", "successfully saved file");
            }

            else
            {
                await this.ShowMessageAsync("Information", "Operation Canceled");
            }




        }

        private void TabItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

            TXTName.Text = string.Empty;
        }
    }
}