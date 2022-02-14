using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;

namespace ClienteConsola.Menu
{
    public class MenuIngresarCliente
    {
        private Cliente Cliente {get ; set; }
        private MenuCompuesto UsuarioPrincipal {get ; set ;}

        public override void mostrar()
        {
            base.mostrar()

            var mail = prompt("Ingrese su mail: ");
            var pass = prompt("Ingrese su contraseña: ");

            try 
            {
                Cliente = AdoCine.ado.ClientePorMailPass(mail, pass)
                if(cliente is null)
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
        private void instanciarMenuesPara(cliente cliente)
        {
            var menuingrearcliente = new MenuIngresarCliente(cliente)
            UsuarioPrincipal = new MenuCompuesto(menuingrearcliente) { Nombre = "Menu cliente"};
        }
    }
}