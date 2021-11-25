using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;

namespace AdminConsola.Menu
{
    public class MenuAltaPelicula : MenuComponente
    {
        private Pelicula Pelicula { get; set; } 

        public MenuAltaPelicula()
        {
            Nombre = "Alta Pelicula";
        }
        
        public override void mostrar()
        {
            base.mostrar();

            var genero = prompt("Ingrese el genero: ");
            var dia = Convert.ToInt32(prompt("Ingrese el dia: " ));
            var mes = Convert.ToInt32(prompt("Ingrese el mes: "));
            var ano = Convert.ToInt32(prompt("Ingrese el año: "));
            var nombre = prompt("Ingrese el nombre: ");
            
            var fecha = new DateTime(year:ano, month:mes, day:dia);
            Pelicula = new Pelicula(genero, fecha, nombre);

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