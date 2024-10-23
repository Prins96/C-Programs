using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace practicaVueling
{
    internal class Program
    {
        private static String ciudadOrigen;
        private static String ciudadDestino;
        private static DateTime fechaIda, fechaRegreso;
        private static TimeSpan horaIda, horaRegreso;
        private static int numPasajeros;
        private static double precioIdaTotal;
        private static double PlanTimeFlex = 100;
        private static double PlanOptima = 40;
        private static double PlanBasico = 0;
        private static double precioRegresoTotal;
        private static String nombre, apellido, email, password, DNI;
        private static List<Clientes> pasajeros;


        static void Main(string[] args)
        {
            int opcion = -1;
            do
            {
                opcion = Menus.MenuPrincipal();
                ElegirOpcion(opcion);
            } while (opcion != 0);
            Console.ReadLine();
        }

        /// <summary>
        /// Una vez elegida la opción del Menú, o bien salimos, o buscamos el vuelo
        /// </summary>
        /// <param name="opcion"></param>
        private static void ElegirOpcion(int opcion)
        {
            switch (opcion)
            {
                case 0:
                    Console.WriteLine("Gracias por elegirnos");
                    break;
                case 1:
                    int subOpcion = Menus.SubMenu();
                    ElegirOpcionSubMenu(subOpcion);
                    break;
            }
        }

        private static void ElegirOpcionSubMenu(int subOpcion)
        {
            switch (subOpcion)
            {
                case 0:
                    ConfirmarIda();
                    break;
                case 1:
                    ConfirmarIdaVuelta();
                    break;
            }
        }
        private static void ElegirPlanViaje(int Opcion)
        {
            switch (Opcion)
            {
                case 0:
                    TimeFlex();
                    break;
                case 1:
                    Optima();
                    break;
                case 2:
                    Basico();
                    break;
            }
        }
        private static void RegistarDatos(int Opcion)
        {
            switch (Opcion)
            {
                case 0:
                    Registro();
                    break;
                case 1:
                    Acceso();
                    break;
                case 2:
                    ContinuarSinRegistrar();
                    break;
            }
        }

        private static void SoloIDa()
        {
            ciudadOrigen = VueloIda.CiudadOrigen();
            ciudadDestino = VueloIda.CiudadDestino(ciudadOrigen);
            fechaIda = VueloIda.FechaIda();
            var horaPrecio = VueloIda.HoraPrecioIda();
            horaIda = horaPrecio.Keys.First();
            double precio = horaPrecio[horaIda];
            Console.WriteLine("hora: " + horaIda + " Precio: " + precio + " euros");
            numPasajeros = VueloIda.NumPasajeros();
            precioIdaTotal = VueloIda.CalcularPrecio(numPasajeros, precio);
            Console.WriteLine("Precio ida: " + precioIdaTotal + " Total pasajeros: " + numPasajeros);
        }
        public static void ConfirmarIda()
        {
            Viaje viaje = new Viaje();
            SoloIDa();
            int opcion = Menus.PlanViaje();
            ElegirPlanViaje(opcion);
            Console.WriteLine("El total del viaje es: " + precioIdaTotal);
            int opcionCliente = Menus.Registrarse();
            RegistarDatos(opcionCliente);

            if (VueloIda.ConfirmarReservaIda())
            {
                viaje.CiudadOrigenIda = ciudadOrigen;
                viaje.CiudadDestinoIda = ciudadDestino;
                viaje.FechaIda = fechaIda;
                viaje.HoraIda = horaIda;
                viaje.PasajerosIda = numPasajeros;
                viaje.PrecioTotal += precioIdaTotal;
                MostrarInformacion(viaje);

            }
            else
            {
                Console.WriteLine("Vuelva pronto");
            }
        }

        private static void IdaVuelta()
        {            
            double precioRegreso;
            SoloIDa();
            Console.WriteLine("");
            do
            {
                fechaRegreso = VueloRegreso.FechaRegreso(fechaIda);
                var horaPrecioRegreso = VueloIda.HoraPrecioIda();
                horaRegreso = horaPrecioRegreso.Keys.First();
                precioRegreso = horaPrecioRegreso[horaRegreso];
                if (fechaIda == fechaRegreso && horaIda >= horaRegreso)
                {
                    Console.WriteLine("La hora de regreso no puede ser menor o igual a la hora de IDA");
                }
                else
                {
                    Console.WriteLine("Hora: " + horaRegreso+ " Precio: " + precioRegreso + " euros");
                }
            } while (fechaIda == fechaRegreso && horaIda >= horaRegreso);
            precioRegresoTotal = VueloIda.CalcularPrecio(numPasajeros, precioRegreso);
            int opcion = Menus.PlanViaje();
            ElegirPlanViaje(opcion);
            Console.WriteLine("El total del viaje es: " + (precioIdaTotal + precioRegresoTotal));
        }

        public static void ConfirmarIdaVuelta()
        {
            Viaje viaje = new Viaje();
            IdaVuelta();

            if (VueloIda.ConfirmarReservaIda())
            {

                viaje.CiudadOrigenIda = ciudadOrigen;
                viaje.CiudadDestinoIda = ciudadDestino;
                viaje.FechaIda = fechaIda;
                viaje.HoraIda = horaIda;
                viaje.PasajerosIda = numPasajeros;
                viaje.CiudadOrigenRegreso = ciudadDestino;
                viaje.CiudadDestinoRegreso = ciudadOrigen;
                viaje.FechaRegreso = fechaRegreso;
                viaje.HoraRegreso = horaRegreso;
                viaje.PasajerosRegreso = numPasajeros;
                viaje.PrecioTotal += precioRegresoTotal + precioIdaTotal;
                MostrarInformacion(viaje);
            }
            else
            {
                Console.WriteLine("Vuelva pronto");
            }
        }
        private static void Basico() => precioIdaTotal += PlanBasico;

        private static void Optima() => precioIdaTotal += PlanOptima;

        private static void TimeFlex() => precioIdaTotal += PlanTimeFlex;
        private static void ContinuarSinRegistrar()
        {
            Clientes cliente = new Clientes();
            pasajeros = new List<Clientes>();

            for (int i = 0; i < numPasajeros; i++)
            {
                nombre = ValidarClientes.NombreOApellidoCliente("Introduce tu nombre: ");
                apellido = ValidarClientes.NombreOApellidoCliente("Introduce tu apellido: ");
                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                pasajeros.Add(cliente);
            }
            
            
        }

        private static void Acceso()
        {
            Console.WriteLine("Estamos teniendo problemas tecnicos");
        }

        private static void Registro()
        {
            Clientes cliente = new Clientes();
            pasajeros = new List<Clientes>();

           /* for (int i = 0; i < numPasajeros; i++)
            {*/
                nombre = ValidarClientes.NombreOApellidoCliente("Introduce tu nombre: ");
                apellido = ValidarClientes.NombreOApellidoCliente("Introduce tu apellido: ");
                email = ValidarClientes.Email();
                String contraseña = ValidarClientes.Password();
                do
                {
                    Console.Write("Vuelve a escribir la contraseña: ");
                    password = Console.ReadLine();
                    if (!contraseña.Equals(password))
                    {
                        Console.WriteLine("La contraseña no coincide, vuelve a intentarlo");
                    }
                } while (!contraseña.Equals(password));
                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.Email = email;
                cliente.password = password;
                pasajeros.Add((cliente));
            //}

        }

        private static void MostrarInformacion(Viaje viaje)
        {
            Console.WriteLine("Resumen del Viaje:");
            Console.WriteLine("Ciudad de Origen (Ida): " + viaje.CiudadOrigenIda);
            Console.WriteLine("Ciudad de Destino (Ida): " + viaje.CiudadDestinoIda);
            Console.WriteLine("Fecha de Ida: " + viaje.FechaIda.ToString("dd/MM/yyyy"));
            Console.WriteLine("Hora de Salida (Ida): " + viaje.HoraIda);
            Console.WriteLine("Número de Pasajeros (Ida): " + viaje.PasajerosIda);

            if (!string.IsNullOrEmpty(viaje.CiudadOrigenRegreso) && !string.IsNullOrEmpty(viaje.CiudadDestinoRegreso))
            {
                Console.WriteLine("");
                Console.WriteLine("Ciudad de Origen (Regreso): " + viaje.CiudadOrigenRegreso);
                Console.WriteLine("Ciudad de Destino (Regreso): " + viaje.CiudadDestinoRegreso);
                Console.WriteLine("Fecha de Regreso: " + viaje.FechaRegreso.ToString("dd/MM/yyyy"));
                Console.WriteLine("Hora de Salida (Regreso): " + viaje.HoraRegreso);
                Console.WriteLine("Número de Pasajeros (Regreso): " + viaje.PasajerosRegreso);
            }
            Console.WriteLine("Precio Total: " + viaje.PrecioTotal);
            foreach (var kvp in pasajeros)
            {
                Console.WriteLine("Nombre: " + kvp.Nombre);
                Console.WriteLine("Apellido: " + kvp.Apellido);
                if (!string.IsNullOrEmpty(kvp.Email))
                {
                    Console.WriteLine("Email: " + kvp.Email);
                    Console.WriteLine("Pass: ****");
                    Console.WriteLine("DNI: " + kvp.DNI);
                }
            }
        }
    }
}
