using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Teclado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int UpperLower, ocultar;
        public MainWindow()
        {
            InitializeComponent();
            UpperLower = 0;
            ocultar = 0;
        }

        private void Write_Space(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            tbResultado.Text += " ";

        }

        private void Write_Button(object sender, RoutedEventArgs e)
        {
            if (UpperLower == 0)
            {
                Button button = (Button)sender;
                tbResultado.Text += button.Content.ToString().ToLower();
            } else if (UpperLower == 1) 
            {
                Button button = (Button)sender;
                tbResultado.Text += button.Content.ToString();
                UpperLower = 0;
                buttonShift.Background = new SolidColorBrush(Colors.Lime);
                buttonShift.Foreground = new SolidColorBrush(Colors.Red);
            } else if (UpperLower == 2)
            {
                Button button = (Button)sender;
                tbResultado.Text += button.Content.ToString();
            }
         }

        private void UpperOrLower(object sender, RoutedEventArgs e)
        {
            if (UpperLower == 0)
            {
                UpperLower = 1;
                buttonShift.Background = new SolidColorBrush(Colors.Orange);
                buttonShift.Foreground = new SolidColorBrush(Colors.Lime);
                
            }
            else if (UpperLower == 1)
            {
                UpperLower = 2;
                buttonShift.Background = new SolidColorBrush(Colors.Red);
                buttonShift.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                UpperLower = 0;
                buttonShift.Background = new SolidColorBrush(Colors.Lime);
                buttonShift.Foreground = new SolidColorBrush(Colors.Red);
            }

        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            String eliminar = null;
            if (tbResultado.Text.Length > 0) {
                for (int i = 0; i < tbResultado.Text.Length - 1; i++) {
                    eliminar += tbResultado.Text[i];
                }
            }
            tbResultado.Text = eliminar;
        }

        private void NewLine_Button(object sender, RoutedEventArgs e)
        {
            tbResultado.Text += "\n";
        }

        private void Redimention_Button(object sender, RoutedEventArgs e)
        {
            if (ocultar == 0)
            {
                ocultar = 1;
                column11.Width = new GridLength(1, GridUnitType.Star);
                column12.Width = new GridLength(1, GridUnitType.Star);
                column13.Width = new GridLength(1, GridUnitType.Star);
                column14.Width = new GridLength(1, GridUnitType.Star);
                
            } else
            {
                ocultar = 0;
                column11.Width = new GridLength(0, GridUnitType.Star);
                column12.Width = new GridLength(0, GridUnitType.Star);
                column13.Width = new GridLength(0, GridUnitType.Star);
                column14.Width = new GridLength(0, GridUnitType.Star);
            }
        }
    }
}
