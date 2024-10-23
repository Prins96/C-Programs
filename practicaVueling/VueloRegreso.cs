using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaVueling
{
    internal class VueloRegreso
    {
        public static DateTime FechaRegreso(DateTime fechaIda)
        {
            DateTime fechaActual = DateTime.Today;
            string format = "dd/MM/yyyy";
            DateTime fechaVuelo;

            do
            {
                Console.Write("Introduzca la fecha de regreso (dd/mm/aaaa): ");
                string data = Console.ReadLine();

                if (DateTime.TryParseExact(data, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaVuelo))
                {
                    if (fechaVuelo >= fechaActual && fechaVuelo >= fechaIda && fechaVuelo <= fechaActual.AddMonths(6))
                    {
                        return fechaVuelo; // Fecha válida, salir del bucle
                    }
                    else
                    {
                        Console.WriteLine("Debe introducir una fecha válida que sea igual o posterior a la fecha actual o la fecha de ida y no esté más de 6 meses en el futuro.");
                    }
                }
                else
                {
                    Console.WriteLine("El formato de fecha es incorrecto. Debe ser dd/mm/aaaa.");
                }
            } while (true); // Repetir hasta que se ingrese una fecha válida
        }
    }
}
