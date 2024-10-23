using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace practicaVueling
{
    internal class ValidarClientes
    {
        public static String NombreOApellidoCliente(String mensaje)
        {
            String nombre;
            do
            {
                Console.Write(mensaje);
                nombre = Console.ReadLine();
                if (ValidarNombre(nombre))
                    return nombre;
                else
                {
                    Console.WriteLine("El nombre o apellido no es valido");
                }
            } while (true);
        }
        public static String Email()
        {
            String email;
            do
            {
                Console.Write("Introduce un email: ");
                email = Console.ReadLine();
                if (ValidarEmail(email))
                    return email;
                else
                {
                    Console.WriteLine("El email no es valido");
                }
            } while (true);
        }

        public static String Password()
        {
            String pass;
            do
            {
                Console.Write("Introduce una contraseña: ");
                pass = Console.ReadLine();
                if (ValidarContraseña(pass))
                    return pass;
                else
                {
                    Console.WriteLine("El password no es valida");
                }
            } while (true);
        }

        /*public static String DNI ()
        {
            Console.Write("Introduce tu DNI: ");
            string dni = Console.ReadLine();
            string messages = met.checkDni(dni);
            Console.WriteLine(messages);
        }*/

        static bool ValidarNombre(string nombreApellido)
        {
            // Validar que nombre o Apellido contenga solo letras y espacios en blanco
            return Regex.IsMatch(nombreApellido, "^[A-Za-z ]+$");
        }

        static bool ValidarEmail(string email)
        {
            // Validar que email tenga un '@' seguido de un '.' después
            return Regex.IsMatch(email, @"^.+@.+\..+$");
        }

        static bool ValidarContraseña(string contraseña)
        {
            // Validar que contraseña tenga entre 5 y 10 caracteres, al menos una letra mayúscula y al menos un número
            return Regex.IsMatch(contraseña, @"^(?=.*[A-Z])(?=.*\d).{5,10}$");
        }


    }
}
