using MySql.Data.MySqlClient;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReservesDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;

        public ReservesDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        /// <summary>
        /// Inserta una nueva reserva en la base de datos MySQL con los datos proporcionados por el usuario
        /// </summary>
        /// <param name="nuevaReserva"></param>
        /// <returns></returns>
        public bool InsertarReserva(Reserves nuevaReserva)
        {
            String query = "INSERT INTO reserves (nom_empresa, data, llocs_de_treball, equip_informatic, tel, obs) VALUES (@nom_empresa, @data, @llocs_de_treball, @equip_informatic, @tel, @obs)";
            bool exito = false;
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    Console.WriteLine("Conexión establecida");
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nom_empresa", nuevaReserva.Nom_empresa);
                        cmd.Parameters.AddWithValue("@data", nuevaReserva.Data.ToString("yyyy/MM/dd"));
                        cmd.Parameters.AddWithValue("@llocs_de_treball", nuevaReserva.Llocs_de_treball);
                        cmd.Parameters.AddWithValue("@equip_informatic", nuevaReserva.Equip_informatic);
                        cmd.Parameters.AddWithValue("@tel", nuevaReserva.Tel);
                        cmd.Parameters.AddWithValue("@obs", nuevaReserva.Obs);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("La reserva se ha insertado correctamente.");
                            exito = true;
                        }
                        else
                        {
                            Console.WriteLine("No se pudo insertar la reserva.");
                        }
                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error MySql en reserves el de ReservesDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en la reserves - ReservesDAO: " + error2.Message);
            }
            return exito;
        }


        /// <summary>
        /// Lista todas las reservas de la base de datos y las devuelve en una lista de objetos
        /// </summary>
        /// <returns></returns>
        public List<Reserves> ObtenerReserves()
        {
            List<Reserves> reservas = new List<Reserves>();
            String query = "SELECT * FROM reserves";
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    Console.WriteLine("Conexión establecida");
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            //recorremos el reader para obtener los datos de la BBDD
                            while (reader.Read())
                            {
                                Reserves reserva = new Reserves()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Nom_empresa = reader.GetString(reader.GetOrdinal("nom_empresa")),
                                    Data = reader.GetDateTime(reader.GetOrdinal("data")),
                                    Llocs_de_treball = reader.GetInt32(reader.GetOrdinal("llocs_de_treball")),
                                    Equip_informatic = reader.GetString(reader.GetOrdinal("equip_informatic")),
                                    Tel = reader.GetInt32(reader.GetOrdinal("tel")),
                                    Obs = reader.GetString(reader.GetOrdinal("obs"))
                                };
                                reservas.Add(reserva);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found in login - ArticlesDAO.");
                        }
                        reader.Close();
                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error MySql en reserves el de ReservesDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en la reserves - ReservesDAO: " + error2.Message);
            }
            return reservas;
        }

    }
}
