using Controllers;
using System;
using System.Collections.Generic;
using System.Windows;
using Models;

namespace LoginWPF
{
    public partial class MainWindow : Window
    {
        private UsersController controller;
        //private const string EmptyCredentialsMessage = "Username or password are empty! Please, introduce your credentials.";
        //private const string ShowPasswordText = "Mostrar contraseña";
        //private const string HidePasswordText = "Ocultar contraseña";
        private List<String> meses = new List<string>() { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        private Dictionary<string, int> monthNamesToNumbers = new Dictionary<string, int>()
{
    { "Enero",  1 },
    { "Febrero",  2 },
    { "Marzo",  3 },
    { "Abril",  4 },
    { "Mayo",  5 },
    { "Junio",  6 },
    { "Julio",  7 },
    { "Agosto",  8 },
    { "Septiembre",  9 },
    { "Octubre",  10 },
    { "Noviembre",  11 },
    { "Diciembre",  12 }
};

        private List<String> years = new List<string>() { "2022", "2023", "2024" };
        public MainWindow()
        {
            InitializeComponent();
            controller = new UsersController();
            initialComponents();
        }

        /// <summary>
        /// Inicializa los componentes de la ventana principal
        /// </summary>
        private void initialComponents()
        {
            for (int i = 0; i < 31; i++)
            {
                CbDay.Items.Add(i + 1);
            }

            for (int i = 0; i < meses.Count; i++)
            {
                CbMount.Items.Add(meses[i]);
            }
            for (int i = 0; i < years.Count; i++)
            {
                CbYear.Items.Add(years[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                CbCantidadLugares.Items.Add(i + 1);
            }
        }

        /// <summary>
        /// Metodo para cerrar la ventana principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres salir?", "Confirmar Salida", MessageBoxButton.OKCancel, MessageBoxImage.Question);


            if (result == MessageBoxResult.OK)
            {
                Close();
            }
        }

        /// <summary>
        /// Hace visible el formulario de inserción
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Insertar_Click(object sender, RoutedEventArgs e)
        {
            FormularioInsercion.Visibility = Visibility.Visible;
            ListadoReservas.Visibility = Visibility.Collapsed;
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar el listado de reservas y ocultar el formulario de inserción
            FormularioInsercion.Visibility = Visibility.Collapsed;
            ListadoReservas.Visibility = Visibility.Visible;
            List<Reserves> reservas = controller.ObtenerReservas();
            // List<Articles> articles = clientController.selectArticles(orderClient.IdOrder);
            if (reservas != null && reservas.Count > 0)
            {
                LvReservas.Visibility = Visibility.Visible;
                //BtExportar.Visibility = Visibility.Visible;
                LvReservas.ItemsSource = reservas;
            }
            else
            {
                MessageBox.Show("No hay artículos para mostrar");
            }
        }

        /// <summary>
        /// Valida los datos introducidos por el usuario y los envía para introducirlos a la BBDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(TbNombreEmpresa.Text) ||
                CbCantidadLugares.SelectedItem == null ||
                CbDay.SelectedItem == null ||
                CbMount.SelectedItem == null ||
                CbYear.SelectedItem == null ||
                string.IsNullOrWhiteSpace(TbTelefon.Text) ||
                string.IsNullOrWhiteSpace(TbObservaciones.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Intentar convertir el teléfono a un entero
                int telefono = int.Parse(TbTelefon.Text);
                // Validar que el teléfono tenga   9 dígitos
                if (TbTelefon.Text.Length != 9)
                {
                    MessageBox.Show("El teléfono debe tener   9 dígitos.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int monthNumber = monthNamesToNumbers[CbMount.SelectedItem.ToString()];
                // Crear una instancia de Reserves con los datos ingresados
                Reserves nuevaReserva = new Reserves
                {
                    Nom_empresa = TbNombreEmpresa.Text,
                    Data = new DateTime(int.Parse(CbYear.SelectedItem.ToString()), monthNumber, int.Parse(CbDay.SelectedItem.ToString())),
                    Llocs_de_treball = int.Parse(CbCantidadLugares.SelectedItem.ToString()),
                    Equip_informatic = RbPrestemoEquipoSi.IsChecked.Value ? "1" : "0", // Guardar "1" si el usuario seleccionó "Sí", y "0" si seleccionó "No"
                    Tel = int.Parse(TbTelefon.Text),
                    Obs = TbObservaciones.Text
                };
                bool resultado = controller.InsertarReserva(nuevaReserva);
                if (resultado)
                {
                    MessageBox.Show("La reserva se ha insertado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo insertar la reserva. Por favor, inténtelo de nuevo.");
                }

            }
            catch (FormatException)
            {
                // Mostrar un mensaje de error si el formato del teléfono es incorrecto
                MessageBox.Show("El formato del teléfono es incorrecto. Por favor, ingrese un número de teléfono válido.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                TbTelefon.Text = "";
            }
        }
    }
}