using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace juegoMemoria
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerUserInactivity;
        int TamanioColumnasFilas = 4;
        int Movimientos = 0;
        int CantidadDeCartasVolteadas = 0;
        List<string> CartasEnumeradas;
        List<string> CartasRevueltas;
        List<Image> CartasSeleccionadas;
        Image CartaTemporal1, CartaTemporal2;
        int CartaActual = 0;
        Grid grid;

        private bool cartasVolteadasIguales = false;

        public MainWindow()
        {
            InitializeComponent();

            iniciarJuego();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Ajustar el intervalo según sea necesario
            timer.Tick += Timer_Tick;


            timerUserInactivity = new DispatcherTimer();
            timerUserInactivity.Interval = TimeSpan.FromSeconds(15);
            timerUserInactivity.Tick += TimerUserInactivity_Tick;
        }

        public void iniciarJuego()
        {
            if (timer != null)
            {
                timer.Stop();
            }
            lblRecord.Content = "0";
            CantidadDeCartasVolteadas = 0;
            Movimientos = 0;
            PanelJuego.Children.Clear();
            CartasEnumeradas = new List<string>() { "1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8" };
            CartasRevueltas = new List<string>();
            CartasSeleccionadas = new List<Image>();

            
            CartasRevueltas = BarajarLista(CartasEnumeradas);

            grid = new Grid();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < TamanioColumnasFilas; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            double porcentaje = 150f / (float)TamanioColumnasFilas - 10;
            for (int i = 0; i < TamanioColumnasFilas; i++)
            {
                grid.RowDefinitions[i].Height = new GridLength(porcentaje, GridUnitType.Star);
                grid.ColumnDefinitions[i].Width = new GridLength(porcentaje, GridUnitType.Star);
            }

            int contadorFichas = 0;
            for (var i = 0; i < TamanioColumnasFilas; i++)
            {
                for (var j = 0; j < TamanioColumnasFilas; j++)
                {
                    var CartasJuego = new Image();
                    CartasJuego.Name = $"Carta_{CartasRevueltas[contadorFichas]}";
                    CartasJuego.Stretch = Stretch.Fill;
                    CartasJuego.Source = new BitmapImage(new Uri("/Girada.jpg", UriKind.Relative));
                    CartasJuego.Cursor = Cursors.Hand;
                    CartasJuego.MouseLeftButtonDown += btnCarta_Click;
                    Grid.SetRow(CartasJuego, i);
                    Grid.SetColumn(CartasJuego, j);
                    grid.Children.Add(CartasJuego);
                    contadorFichas++;
                }
            }


            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.VerticalAlignment = VerticalAlignment.Stretch;
            PanelJuego.Children.Add(grid);
        }

        static List<string> BarajarLista(List<string> lista)
        {
            Random randomGenerator = new Random();
            List<string> listaBarajada = lista.OrderBy(item => randomGenerator.Next()).ToList();
            return listaBarajada;
        }

        private void btnReiniciar_Click(object sender, RoutedEventArgs e)
        {
            iniciarJuego();
        }

        private void btnCarta_Click(object sender, MouseButtonEventArgs e)
        {

            if (CartasSeleccionadas.Count < 2)
            {
                timerUserInactivity.Start();
                Movimientos++;
                lblRecord.Content = Convert.ToString(Movimientos);
                var CartaSeleccionada = (Image)sender;

                CartaActual = int.Parse(CartaSeleccionada.Name.Substring(6));
                string nameCarta = "/img" + CartaActual + ".jpg";

                CartaSeleccionada.Source = RecuperarImagen(CartaActual);
                CartasSeleccionadas.Add(CartaSeleccionada);
                //lblImagenSelecciona.Content = nameCarta;
                if (CartasSeleccionadas.Count == 2)
                {
                    CartaTemporal1 = CartasSeleccionadas[0];
                    CartaTemporal2 = CartasSeleccionadas[1];
                    int Carta1 = int.Parse(CartaTemporal1.Name.Substring(6).Replace("Carta_", ""));
                    int Carta2 = int.Parse(CartaTemporal2.Name.Substring(6).Replace("Carta_", ""));
                    if (Carta1 != Carta2)
                    {
                        timer.Start();
                        grid.IsEnabled = false;
                    }
                    else
                    {
                        CantidadDeCartasVolteadas++;
                        if (CantidadDeCartasVolteadas > 7)
                        {
                            MessageBox.Show("El juego ha terminado");
                        } else if (Movimientos >= 24)
                        {
                            MessageBox.Show("Has perdido");
                        }
                        CartaTemporal1.IsEnabled = false;
                        CartaTemporal2.IsEnabled = false;
                    }
                    CartasSeleccionadas.Clear();
                    timerUserInactivity.Stop();
                }

            }
        }
        public BitmapImage RecuperarImagen(int NumeroImagen)
        {
            BitmapImage TmpImg = new BitmapImage();
            String nameCarta = "/img" + NumeroImagen + ".jpg";
            switch (NumeroImagen)
            {
                case 0:
                    TmpImg = new BitmapImage(new Uri("/img11.jpg", UriKind.Relative));
                    break;
                default:
                    TmpImg = new BitmapImage(new Uri(nameCarta, UriKind.Relative));
                    break;
            }
            return TmpImg;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            grid.IsEnabled = true;
            if (!cartasVolteadasIguales)
            {
                CartaTemporal1.Source = new BitmapImage(new Uri("/Girada.jpg", UriKind.Relative));
                CartaTemporal2.Source = new BitmapImage(new Uri("/Girada.jpg", UriKind.Relative));
                cartasVolteadasIguales = true;
            }
            else
            {
                timer.Stop();
                cartasVolteadasIguales = false;
            }
        }
        private void TimerUserInactivity_Tick(object sender, EventArgs e)
        {
            timerUserInactivity.Stop(); // Detiene el temporizador
            MessageBox.Show("Has perdido por no jugar"); // Muestra el mensaje al usuario
        }

    }
}