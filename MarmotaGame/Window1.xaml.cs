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

namespace MarmotaGame
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void BtPlay_Click(object sender, RoutedEventArgs e)
        {
            /*if (Rba1.IsChecked == true)
            {
                string nombreImagen = ObtenerNombreImagen(Rba1);
                // Puedes hacer algo con el nombre de la imagen, como mostrarlo en un MessageBox
                MessageBox.Show($"Nombre de la imagen seleccionada: {nombreImagen}");
            }
            else if (Rba2.IsChecked == true)
            {
                string nombreImagen = ObtenerNombreImagen(Rba2);
                MessageBox.Show($"Nombre de la imagen seleccionada: {nombreImagen}");
            }
            else if (Rba3.IsChecked == true)
            {
                string nombreImagen = ObtenerNombreImagen(Rba3);
                MessageBox.Show($"Nombre de la imagen seleccionada: {nombreImagen}");
            }
            else if (Rba4.IsChecked == true)
            {
                string nombreImagen = ObtenerNombreImagen(Rba4);
                MessageBox.Show($"Nombre de la imagen seleccionada: {nombreImagen}");
            }
            */

           // this.Close();

            // Crear una nueva instancia de MainWindow y pasar el nombre de la imagen
            //MainWindow mainWindow = new MainWindow(nombreImagen);
           // mainWindow.ShowDialog();
        }

        
    }
}
