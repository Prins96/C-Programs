using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace MarmotaGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int NumeroMarmotaActual = 1;
        int TiempoNivel = 20;
        int Puntuacion = 0;
        int Fallas = 0;
        int LimiteFallas = 3;
        int columns = 3, rows = 3;
        Random rnd = new Random();
        int marmotaSeleccionada = 0;
        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();

        public MainWindow()
        {

            InitializeComponent();
            IniciarJuego();
        }

        public void IniciarJuego()
        {
            NumeroMarmotaActual = 1;
            TiempoNivel = 20;
            Puntuacion = 0;
            Fallas = 0;
            LimiteFallas = 3;
            lblPuntos.Content = "0";
            lblFallas.Content = "0";
            PanelJuego.Children.Clear();

            // Obtener el nombre del archivo sin la extensión
            string nombreArchivo = System.IO.Path.GetFileNameWithoutExtension(ImMarmota.Source.ToString());
            // Tomar la parte numérica de la cadena (después de la letra "a")
            string parteNumerica = nombreArchivo.Substring(1);
            // Convertir la parte numérica a un entero
            if (!int.TryParse(parteNumerica, out marmotaSeleccionada))
            {
                Console.WriteLine("No se pudo convertir la parte numérica a entero.");
            }


            for (var i = 0; i < columns; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    var FichaJuego = new Image();
                    FichaJuego.Source = new BitmapImage(new Uri("/Resources/AgujeroVacio.png", UriKind.Relative));
                    FichaJuego.Name = $"M{i}_{j}";
                    //FichaJuego.Stretch = System.Windows.Media.Stretch.Fill;
                    //FichaJuego.Cursor = System.Windows.Input.Cursors.Hand;
                    FichaJuego.MouseLeftButtonDown += Jugar;
                    FichaJuego.Tag = "No";

                    Grid.SetRow(FichaJuego, i);
                    Grid.SetColumn(FichaJuego, j);

                    PanelJuego.Children.Add(FichaJuego);
                }
            }

            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;

            timer2.Interval = TimeSpan.FromMilliseconds(1000);
            timer2.Tick += timer2_Tick;

            timer1.Start();
            timer2.Start();
        }

        private void Jugar(object sender, MouseButtonEventArgs e)
        {
            var FichaSeleccionadaUsuario = (Image)sender;
            if (FichaSeleccionadaUsuario.Tag.ToString() != "No")
            {
                Lbmarmota.Content = FichaSeleccionadaUsuario.Tag.ToString();
                int marmota = Convert.ToInt32(FichaSeleccionadaUsuario.Tag.ToString().Substring(8, 1));
                if (marmota == marmotaSeleccionada)
                {
                    Sonido("bien");
                    Puntuacion++;
                    lblPuntos.Content = Puntuacion.ToString();
                    timer1.Interval = TimeSpan.FromMilliseconds(timer1.Interval.TotalMilliseconds - TiempoNivel);
                }
                else
                {
                    Fallas++;
                    lblFallas.Content = Fallas.ToString();
                    Sonido("falla");
                }
            }
            else
            {
                Sonido("error");
            }
        }

        public void Sonido(string soundName)
        {
            var sound = new MediaPlayer();
            sound.Open(new Uri($"Resources/{soundName}.wav", UriKind.Relative));
            sound.Play();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            /*foreach (UIElement element in PanelJuego.Children)
            {
                var pbOcultar = (Image)element;
                pbOcultar.Source = new BitmapImage(new Uri("/Resources/AgujeroVacio.png", UriKind.Relative));
                pbOcultar.Tag = "No";
                
            }*/
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var pbOcultar = (Image)PanelJuego.Children
                        .Cast<UIElement>()
                        .First(element => Grid.GetRow(element) == i && Grid.GetColumn(element) == j);

                    pbOcultar.Source = new BitmapImage(new Uri("/Resources/AgujeroVacio.png", UriKind.Relative));
                    pbOcultar.Tag = "No";
                }
            }


            int rndColor = rnd.Next(1, 5);
            int rndi = rnd.Next(0, 3);
            int rndj = rnd.Next(0, 3);
            var pbx = (Image)PanelJuego.Children.Cast<UIElement>().First(element => Grid.GetRow(element) == rndi && Grid.GetColumn(element) == rndj);

            pbx.Source = new BitmapImage(new Uri("/Resources/marmota_" + rndColor + ".png", UriKind.Relative));
            pbx.Tag = "marmota_" + rndColor;

            if (Fallas == LimiteFallas)
            {
                timer1.Stop();
                MessageBox.Show("Juego terminado puntos = " + lblPuntos.Content);
                timer2.Stop();
                IniciarJuego();

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int NumeroMarmota = rnd.Next(1, 5);
            NumeroMarmotaActual = NumeroMarmota;
            //ImMarmota.Source = new BitmapImage(new Uri("/Resources/a" + NumeroMarmotaActual + ".png", UriKind.Relative));
        }
    }
}
