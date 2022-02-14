using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;

namespace ClienteConsola.Menu
{
    public class MenuAltaCliente : MenuComponente
    {
        private Cliente Cliente {get;set;}
        public MenuAltaCliente()
        {
            Nombre = "Alta Cliente";
        }


        public override void mostrar()
        {
            base.mostrar();

            var nombre = prompt("Ingrese su nombre: ");
            var apellido = prompt("Ingrese su apellido: ");
            var mail = prompt("Ingrese su mail: ");
            var pass = prompt("Ingrese su contraseña: ");

            Cliente = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                Mail = mail,
                Pass = pass
            };

            try
            {
                Program.Ado.AltaCliente(Cliente);
                Console.WriteLine("Se dio de alta el cliente correctamente");
            }
            catch (Exception e)
            {
                
                Console.WriteLine($"No se pudo dar de alta el cliente: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}