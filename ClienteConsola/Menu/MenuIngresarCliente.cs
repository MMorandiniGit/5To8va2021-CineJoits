using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;

namespace ClienteConsola.Menu
{
    public class MenuIngresarCliente:MenuComponente
    {
        public MenuIngresarCliente(Cliente cliente)
        {
            Cliente = cliente;
        }

        private Cliente Cliente {get ; set; }
        private MenuCompuesto UsuarioPrincipal {get ; set ;}

        public override void mostrar()
        {
            base.mostrar();

            var mail = prompt("Ingrese su mail: ");
            var pass = prompt("Ingrese su contraseña: ");

            try 
            {
                Cliente = Program.Ado.IngresarCliente(mail, pass);
                if(Cliente is null)
                {
                    Console.WriteLine("Mail o contraseña incorrecta");
                    Console.ReadKey();
                }
                else
                {
                    instanciarMenuesPara(Cliente);
                    UsuarioPrincipal.mostrar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo iniciar sesion debido a un error: {e.Message}");
                Console.ReadKey();
            }
        }
        private void instanciarMenuesPara(Cliente cliente)
        {
            var menualtacliente = new MenuIngresarCliente(cliente);
            UsuarioPrincipal = new MenuCompuesto(menualtacliente) { Nombre = "Menu cliente"};
        }
    }
}