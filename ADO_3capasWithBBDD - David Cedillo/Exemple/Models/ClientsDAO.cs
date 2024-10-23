using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClientsDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;
        public ClientsDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        /// <summary>
        /// Hacemos una consulta a la BBDD para obtener todos los clientes
        /// </summary>
        /// <returns></returns>
        public List<Clients> listClients()
        {
            List<Clients> clients = new List<Clients>();
            String query = "SELECT CLIENTNAME, PHONE, CONTACTEMAIL FROM CLIENTS"; //la consulta que li fem a la BBDD

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
                        //ejecutamos la consulta
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            //recorremos el reader para obtener los datos de la BBDD
                            while (reader.Read())
                            {
                                //creamos un objeto Clients para meter los datos de la BBDD en el objeto
                                Clients client = new Clients()
                                {
                                    ClientName = reader.GetString(reader.GetOrdinal("CLIENTNAME")),
                                    Phone = reader.GetString(reader.GetOrdinal("PHONE")),
                                    ContactEmail = reader.GetString(reader.GetOrdinal("CONTACTEMAIL"))
                                };
                                //añadimos el objeto al listado de objetos
                                clients.Add(client);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found in login - ClientsDAO.");
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error MySql en el login de ClientsDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en el login - ClientsDAO: " + error2.Message);
            }
            return clients;
        }
    }
}
