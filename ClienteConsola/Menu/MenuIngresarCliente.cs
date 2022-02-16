using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;

namespace ClienteConsola.Menu
{
    public class MenuIngresarCliente:MenuComponente
    {
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
                }
                else
                {
                    // instanciarMenuesPara(Cliente);
                    // UsuarioPrincipal.mostrar();
                    System.Console.WriteLine("Adentro");                    
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo iniciar sesion debido a un error: {e.Message} - {e.StackTrace}");
                Console.ReadKey();
            }
        }
        private void instanciarMenuesPara(Cliente cliente)
        {
            UsuarioPrincipal = new MenuCompuesto() { Nombre = "Menu cliente"};
        }
        public MenuIngresarCliente()
        {
            Nombre = "Ingresar cliente";
        }
    }
}