using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;

namespace AdminConsola.Menu
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
            try
            {
                Program.Ado.AltaCliente(Cliente);
                Console.WriteLine("Se dio de alta la pelicula correctamente");
            }
            catch (Exception e)
            {
                
                Console.WriteLine($"No se pudo dar de alta el cliente: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}