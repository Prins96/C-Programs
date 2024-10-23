using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaVueling
{
    internal class Menus
    {

        /// <summary>
        /// Mostramos el menú principal con las opciones
        /// </summary>
        /// <returns>opcion</returns>
        public static int MenuPrincipal()
        {
            bool continua = true;
            int opcion = -1;
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-- MENU PRINCIPAL --");
            do
            {
                try
                {
                    //Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("0. Salir");
                    Console.WriteLine("1. Buscar vuelo");
                    Console.Write("Ingrese una opcion: ");
                    opcion = Int32.Parse(Console.ReadLine());
                    if (opcion >= 0 && opcion <= 1)
                    {
                        continua = false;
                    }
                    else
                    {
                        //Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La opcion elegida no es correcta, vuelva a intentarlo");
                    }
                }
                catch (FormatException e)
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }

            } while (continua);

            return opcion;
        }

        public static int SubMenu()
        {
            bool continuar = true;
            int opcion = -1;
            Console.WriteLine("-- SUBMENU --");
            do
            {
                try
                {
                    Console.WriteLine("0. Vuelo de IDA");
                    Console.WriteLine("1. Vuelo de IDA y VUELTA");
                    Console.Write("Ingrese una opcion: ");
                    opcion = Int32.Parse(Console.ReadLine());
                    if (opcion >= 0 && opcion <= 1)
                    {
                        continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("La opcion elegida no es correcta, vuelva a intentarlo");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (continuar);

            return opcion;
        }

        public static int PlanViaje()
        {
            bool continuar = true;
            int opcion = -1;
            Console.WriteLine("-- Plan de viaje --");
                do
                {
                    try
                    {
                        Console.WriteLine("0. TimeFlex + 100 euros");
                        Console.WriteLine("1. Optima + 40 euros");
                        Console.WriteLine("2. Basico + 0 euros");
                        Console.Write("Ingrese una opcion: ");
                        opcion = Int32.Parse(Console.ReadLine());
                        if (opcion >= 0 && opcion <= 2)
                        {
                            continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("La opcion elegida no es correcta, vuelva a intentarlo");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                } while (continuar);

            return opcion;
        }

        public static int Registrarse()
        {
            bool continuar = true;
            int opcion = -1;
            Console.WriteLine("-- Registrar Datos --");
            do
            {
                try
                {
                    Console.WriteLine("0. Registrarse");
                    Console.WriteLine("1. Acceso (No funciona)");
                    Console.WriteLine("2. Continuar sin registrarse");
                    Console.Write("Ingrese una opcion: ");
                    opcion = Int32.Parse(Console.ReadLine());
                    if (opcion >= 0 && opcion <= 2)
                    {
                        continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("La opcion elegida no es correcta, vuelva a intentarlo");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (continuar);

            return opcion;
        }
    }
}
