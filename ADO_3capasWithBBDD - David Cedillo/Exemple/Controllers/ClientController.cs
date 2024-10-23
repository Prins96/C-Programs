using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class ClientController
    {
        private ClientsDAO clientDao;
        private OrdersDAO orderDao;
        private ArticlesDAO articlesDao;
        public ClientController()
        {
            clientDao = new ClientsDAO();
            orderDao = new OrdersDAO();
            articlesDao = new ArticlesDAO();
        }

        /// <summary>
        /// Devuelve la lista de todos los clientes
        /// </summary>
        /// <returns></returns>
        public List<Clients> listClients()
        {
            List<Clients> clients = clientDao.listClients();
            return (clients != null) ? clients : null;
        }

        /// <summary>
        /// Devuelve un diccionario con el id del pedido y el nombre del cliente
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> orderClients()
        {
            Dictionary<int, string> clients = orderDao.getIdOrderNameClient();
            return (clients != null) ? clients : null;
        }

        /// <summary>
        /// Devuelve la lista de todos los pedidos de un cliente concreto por el IDORDER
        /// </summary>
        /// <param name="idOrder"></param>
        /// <returns></returns>
        public List<Articles> selectArticles(int idOrder)
        {
            List<Articles> art = articlesDao.getArticlesByIdOrder(idOrder);
            return (art != null) ? art : null;
        }


    }
}
