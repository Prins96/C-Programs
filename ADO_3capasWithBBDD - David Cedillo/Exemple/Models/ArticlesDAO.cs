using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Models
{
    public class ArticlesDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;
        public ArticlesDAO()
        {
            dbConnect = DBConnection.getInstance();
        }
        /// <summary>
        /// Hacemos una consulta a la BBDD para obtener todos los articulos por id de pedido
        /// </summary>
        /// <param name="idOrder"></param>
        /// <returns></returns>
        public List<Articles> getArticlesByIdOrder(int idOrder)
        {
            List<Articles> articles = new List<Articles>();
            String query = "select ar.* from articles ar inner join orderdetails od " +
                "on od.idArticle = ar.idArticle " +
                "inner join orders o on " +
                "od.idOrder = o.idOrder " +
                "where o.idOrder =@idOrder;"; //la consulta que li fem a la BBDD

            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    Console.WriteLine("Conexión establecida");
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@idOrder", idOrder));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            //recorremos el reader para obtener los datos de la BBDD
                            while (reader.Read())
                            {
                                Articles article = new Articles()
                                {

                                    IdArticle = reader.GetInt32(reader.GetOrdinal("idArticle")),
                                    ArticleName = reader.GetString(reader.GetOrdinal("articleName")),
                                    UnitPrice = reader.GetFloat(reader.GetOrdinal("unitPrice")),
                                    Availability = reader.GetInt32(reader.GetOrdinal("availability"))
                                };
                                articles.Add(article);
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
                Console.WriteLine("Error MySql en el login de ArticlesDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en el login - ArticlesDAO: " + error2.Message);
            }
            return articles;
        }
    }
}
