using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Models
{
    public class OrdersDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;
        public OrdersDAO()
        {
            dbConnect = DBConnection.getInstance();
        }
        /// <summary>
        /// Hacemos una consulta a la BBDD para obtener todos los pedidos y el nombre del cliente al que pertenece el pedido
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> getIdOrderNameClient()
        {
            Dictionary<int, string> orderClient = new Dictionary<int, string>();
            String query = "SELECT o.idOrder, CL.clientName " +
                "FROM Orders o " +
                "INNER JOIN Clients CL ON o.idClient = CL.idClient"; //la consulta que li fem a la BBDD

            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    Console.WriteLine("Conexión establecida");
                    //abrimos la conexión
                    con.Open();
                    //creamos el comando y le pasamos la consulta y la conexión
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            //recorremos el reader para obtener los datos de la BBDD
                            while (reader.Read())
                            {
                                //creamos un objeto Orders para meter los datos de la BBDD en el objeto
                                Orders orders = new Orders();
                                //creamos un objeto Clients para meter los datos de la BBDD en el objeto
                                Clients clients = new Clients();
                                orders.IdOrder = reader.GetInt32("idOrder");
                                clients.ClientName = reader.GetString("clientName");
                                //añadimos el pedido y el nombre del cliente
                                orderClient.Add(orders.IdOrder, clients.ClientName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found in login - OrdersDAO.");
                        }
                        //cerramos el reader
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error MySql en el login de OrdersDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en el login - OrdersDAO: " + error2.Message);
                Console.WriteLine("Error general en el login - OrdersDAO: " + error2.Message);
            }
            return orderClient;
        }
    }
}
