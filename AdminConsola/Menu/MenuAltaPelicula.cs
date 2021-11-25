using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;


namespace AdminConsola.Menu
{
    public class MenuAltaPelicula : MenuCompuesto
    {
        private Pelicula Pelicula { get; set; } 

        public MenuAltaPelicula()
        {
            Nombre = "Alta Pelicula";
        }
        public override void mostrar()
        {
            base.mostrar();

            var Genero = prompt("Ingrese el genero: ");
            var Fecha = prompt("Ingrese la fecha: ");
            var Nombre = prompt("Ingrese el nombre: ");
            
            
            //Pelicula = new Pelicula(Genero, Fecha, Nombre);

            try
            {
                Program.Ado.AltaPelicula(Pelicula);
                Console.WriteLine("Se dio de alta la pelicula correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo dar de alta la pelicula: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}