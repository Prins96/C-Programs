using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


using System.Windows;

namespace Controllers
{
    public class UsersController
    {
        private ReservesDAO model;
        public UsersController()
        {
            model = new ReservesDAO();
        }

        /// <summary>
        ///  Inserta una nueva reserva en la base de datos y devuelve true o false
        /// </summary>
        /// <param name="nuevaReserva"></param>
        /// <returns></returns>
        public bool InsertarReserva(Reserves nuevaReserva)
        {

            return model.InsertarReserva(nuevaReserva);
        }

        /// <summary>
        ///  Obtiene todas las reservas de la base de datos y las devuelve
        /// </summary>
        /// <returns></returns>
        public List<Reserves> ObtenerReservas()
        {
            List<Reserves> reserves = model.ObtenerReserves();
            if (reserves != null)
            {
                return reserves;
            }
            else
            {
                return null;
            }
        }
    }
}
