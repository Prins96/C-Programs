using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaVueling
{

    internal class VueloIda
    {
        private static List<string> ciudades = new List<string>() {"MÁLAGA", "MADRID", "BARCELONA", "VALENCIA", "SEVILLA"/*, "ZARAGOZA",
            "BILBAO", "MURCIA", "ALICANTE", "CÓRDOBA", "VALLADOLID", "VIGO", "PALMA DE MALLORCA", "LAS PALMAS DE GRAN CANARIA",
            "BADAJOZ", "SANTANDER", "TOLEDO", "PAMPLONA", "VITORIA-GASTEIZ", "CÁDIZ", "OVIEDO", "SALAMANCA", "ALMERÍA", "BURGOS",
            "GRANADA", "ALCALÁ DE HENARES", "TARRAGONA", "LEÓN", "CASTELLÓN DE LA PLANA", "SANTA CRUZ DE TENERIFE"*/};
        private static Dictionary<TimeSpan, double> horasSalidaYPrecios = new Dictionary<TimeSpan, double> {
            { new TimeSpan(8, 40, 0), 24.99 },
            { new TimeSpan(10, 0, 0), 20.99 },
            { new TimeSpan(18, 40, 0), 30.99 },
            { new TimeSpan(20, 0, 0), 34.99 }
        };
        public static String CiudadOrigen()
        {
            String ciudad;
            Boolean continuar = true;
            MostrarCiudades("");
            do
            {
                Console.Write("Ciudad de origen: ");
                ciudad = Console.ReadLine().ToUpper();
                if (ciudades.Contains(ciudad))
                {
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("La ciudad introducida no es correcta");
                }
            } while (continuar);
            return ciudad;
        }

        public static String CiudadDestino(String ciudadOrigen)
        {
            String ciudad;
            Boolean continuar = true;
            MostrarCiudades(ciudadOrigen);
            do
            {
                Console.Write("Ciudad de destino: ");
                ciudad = Console.ReadLine().ToUpper();
                if (ciudad.Equals(ciudadOrigen))
                {
                    Console.WriteLine("La ciudad de destino no puede ser la misma que la ciudad de origen");
                }
                else if (ciudades.Contains(ciudad))
                {
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("La ciudad introducida no es correcta");
                }
            } while (continuar);
            return ciudad;
        }

        private static void MostrarCiudades(String ciudadOrigen)
        {
            foreach (String ciudad in ciudades)
            {
                if (!ciudad.Equals(ciudadOrigen/*, StringComparison.OrdinalIgnoreCase*/))
                {
                    Console.WriteLine(ciudad);
                }
            }
        }


        public static DateTime FechaIda()
        {
            DateTime fechaActual = DateTime.Today;
            string format = "dd/MM/yyyy";
            DateTime fechaVuelo;

            do
            {
                Console.Write("Introduzca la fecha de ida (dd/mm/aaaa): ");
                string data = Console.ReadLine();

                if (DateTime.TryParseExact(data, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaVuelo))
                {
                    if (fechaVuelo >= fechaActual && fechaVuelo <= fechaActual.AddMonths(6))
                    {
                        return fechaVuelo; // Fecha válida, salir del bucle
                    }
                    else
                    {
                        Console.WriteLine("Debe introducir una fecha válida que sea igual o posterior a la fecha actual y no esté más de 6 meses en el futuro.");
                    }
                }
                else
                {
                    Console.WriteLine("El formato de fecha es incorrecto. Debe ser dd/mm/aaaa.");
                }
            } while (true); // Repetir hasta que se ingrese una fecha válida
        }

        public static Dictionary<TimeSpan, double> HoraPrecioIda()
        {
            bool continuar = true;
            int opcion = -1;
            Dictionary<TimeSpan, double> horaPrecioSeleccionado = null;

            do
            {
                try
                {
                    Console.WriteLine("Elija la hora de salida");
                    MostrarHoraPrecio();
                    Console.Write("Ingrese una opcion: ");
                    opcion = Int32.Parse(Console.ReadLine());

                    if (opcion >= 0 && opcion <= 3)
                    {
                        var horaPrecio = horasSalidaYPrecios.ElementAt(opcion);
                        var horaSeleccionada = horaPrecio.Key;
                        var precioSeleccionado = horaPrecio.Value;
                        horaPrecioSeleccionado = new Dictionary<TimeSpan, double> {
                    { horaSeleccionada, precioSeleccionado }
                };
                        continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("La opción elegida no es correcta, vuelva a intentarlo");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (continuar);

            return horaPrecioSeleccionado;
        }



        private static void MostrarHoraPrecio()
        {
            int contador = 0;
            foreach (var kvp in horasSalidaYPrecios)
            {
                Console.WriteLine($"{contador++}. Hora: {kvp.Key}, Precio: {kvp.Value} euros");
            }
        }

        public static int NumPasajeros()
        {
            int numPasajeros = 0;
            bool continuar = true;
            do
            {
                try
                {
                    Console.Write("Introduzca el número de pasajeros: ");
                    numPasajeros = Int32.Parse(Console.ReadLine());
                    if (numPasajeros > 0 && numPasajeros <= 10)
                    {
                        continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("El número de pasajeros debe ser 1 mínimo y 10 máximo");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El formata de entrada no es el correcto" + e.Message);
                }
            } while (continuar);

            return numPasajeros;
        }

        public static double CalcularPrecio(int pasajeros, double precio)
        {
            return precio * pasajeros;
        }

        public static bool ConfirmarReservaIda()
        {
            String confirmacion = null;
            bool confirmar = false;

            Console.WriteLine("Pulse S para continuar, cualquier otro caracter para terminar");
            confirmacion = Console.ReadLine();
            if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                confirmar = true;
            }
            return confirmar;

        }
    }
}
