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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Diseño
{
    /// <summary>
    /// Lógica de interacción para VentanaLogin.xaml
    /// </summary>
    public partial class VentanaLogin : MetroWindow
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }
        

        private void Tile_Click(object sender, RoutedEventArgs e)
        {

           MainWindow mn = new MainWindow();
            this.Close();
            mn.ShowDialog();


        }
    }
}
