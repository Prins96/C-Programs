using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Controllers;
using Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Data;

namespace LoginWPF
{
    public partial class ClientView : Window
    {
        private ClientController clientController;

        public ClientView(string v)
        {
            InitializeComponent();
            clientController = new ClientController();
            lbWhoIs.Content = v != null ? $"Welcome {v}" : "";
            VisibilityAllView(Visibility.Collapsed);
        }
        /// <summary>
        /// Oculta todos los elementos de la vista
        /// </summary>
        /// <param name="visibility"></param>
        private void VisibilityAllView(Visibility visibility)
        {
            dataGridClients.Visibility = visibility;
            myListBox.Visibility = visibility;
            myListView2.Visibility = visibility;
            BtExportar.Visibility = visibility;
        }

        /// <summary>
        /// Lista todos los clientes en la base de datos y los muestra en el ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Listar_button(object sender, RoutedEventArgs e)
        {
            VisibilityAllView(Visibility.Collapsed);
            List<Clients> clients = clientController.listClients();
            if (clients != null)
            {
                // Filtramos la lista para excluir clientes con campos vacíos
                clients = clients.Where(c => !string.IsNullOrEmpty(c.ClientName) && !string.IsNullOrEmpty(c.Phone) && !string.IsNullOrEmpty(c.ContactEmail)).ToList();

                dataGridClients.Visibility = Visibility.Visible;
                dataGridClients.AutoGenerateColumns = false; // Asegúrate de que esta línea esté presente

                // Agrega las columnas manualmente
                dataGridClients.Columns.Add(new DataGridTextColumn
                {
                    Header = "Client Name",
                    Binding = new Binding("ClientName")
                });
                dataGridClients.Columns.Add(new DataGridTextColumn
                {
                    Header = "Phone",
                    Binding = new Binding("Phone")
                });
                dataGridClients.Columns.Add(new DataGridTextColumn
                {
                    Header = "Contact Email",
                    Binding = new Binding("ContactEmail")
                });

                dataGridClients.ItemsSource = clients;
            }
        }



        /// <summary>
        /// Al pulsar CTRL+L, lista todos los clientes en la base de datos y los muestra en el ListBox 
        /// y al pulsar CTRL+I, ordena los clientes por nombre y los muestra en el ListView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.L && Keyboard.Modifiers == ModifierKeys.Control)
            {
                Listar_button(sender, e);
            }
            else if (e.Key == Key.I && Keyboard.Modifiers == ModifierKeys.Control)
            {
                orderClient_button(sender, e);
            }
        }

        /// <summary>
        /// Ordena los clientes por IDORDER y el nombre del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderClient_button(object sender, RoutedEventArgs e)
        {
            VisibilityAllView(Visibility.Collapsed);
            Dictionary<int, String> orderClients = clientController.orderClients();
            if (orderClients != null)
            {
                var orderClientsList = orderClients.Select(kv => new OrderClient { IdOrder = kv.Key, ClientName = kv.Value }).ToList();
                myListBox.Visibility = Visibility.Visible;
                myListBox.ItemsSource = orderClientsList;
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
        }

        /// <summary>
        /// Selecciona los artículos de un cliente por su IDORDER y los muestra en el ListView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectArticles_button(object sender, SelectionChangedEventArgs e)
        {
            OrderClient orderClient = myListBox.SelectedItem as OrderClient;
            if (orderClient != null)
            {
                List<Articles> articles = clientController.selectArticles(orderClient.IdOrder);
                if (articles != null && articles.Count > 0)
                {
                    VisibilityAllView(Visibility.Collapsed);
                    myListView2.Visibility = Visibility.Visible;
                    BtExportar.Visibility = Visibility.Visible;
                    myListView2.ItemsSource = articles;
                }
                else
                {
                    MessageBox.Show("No hay artículos para mostrar");
                }
            }
        }

        /// <summary>
        /// Exporta el ListView2 a un archivo PDF con los datos de los artículos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Crear un nuevo documento PDF
                string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ListViewExport.pdf");
                using (Document document = new Document())
                {
                    // Crear un nuevo escritor PDF que escribe en un archivo
                    PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
                    // Abrir el documento para escritura
                    document.Open();

                    var firstItem = myListView2.Items.Cast<Articles>().FirstOrDefault();
                    // Crear una tabla con el número de columnas basado en las propiedades del objeto
                    PdfPTable table = new PdfPTable(firstItem.GetType().GetProperties().Length);

                    // Agregar encabezados de columna basados en las propiedades del objeto
                    foreach (var property in firstItem.GetType().GetProperties())
                    {
                        table.AddCell(property.Name);
                    }

                    // Agregar filas de datos
                    foreach (var item in myListView2.Items)
                    {
                        if (item is Articles article)
                        {
                            foreach (var property in article.GetType().GetProperties())
                            {
                                table.AddCell(property.GetValue(article, null)?.ToString() ?? string.Empty);
                            }
                        }
                    }

                    // Agregar la tabla al documento
                    document.Add(table);
                }
                // Abrir el archivo PDF con el programa predeterminado
                Process.Start(pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a PDF: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}