using MySql.Data.MySqlClient;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UsersDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;
        public UsersDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        /// <summary>
        /// Este método me detecta si un usuario está en la tabla users
        /// </summary>
        /// <param name="user">user viene dado por el controlador</param>
        /// <returns></returns>
        public Users login(Users user)
        {
            Users u = null;

            
            String query = "SELECT * FROM Users WHERE username=@user AND userpass=@pass"; //la consulta que li fem a la BBDD
            
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    Console.WriteLine("Conexión establecida");
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", user.Username));
                        cmd.Parameters.Add(new MySqlParameter("@pass", user.Password));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                u = new Users()
                                {
                                    Username = reader.GetString(reader.GetOrdinal("username")),
                                    Password = reader.GetString(reader.GetOrdinal("userpass")),
                                    UserEmail = reader.GetString(reader.GetOrdinal("email")),
                                    Role = reader.GetString(reader.GetOrdinal("role"))
                                };
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found in login - UserDAO.");
                        }
                        reader.Close();
                       
                    }
                }
            }catch(MySqlException error1)
            {
                Console.WriteLine("Error MySql en el login d'UserDAO: "+error1.Message);
            }catch(Exception error2)
            {
                Console.WriteLine("Error general en el login - UserDAO: " + error2.Message);
            }
            return u;

        }
    }
}
