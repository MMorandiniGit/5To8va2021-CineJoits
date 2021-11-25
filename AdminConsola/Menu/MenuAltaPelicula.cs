using System;
using MenuesConsola;


namespace AdminConsola.Menu
{
    public class MenuAltaPelicula : MenuCompuesto
    {
        private Pelicula Pelicula { get; set; } 

        public override void mostrar()
        {
            base.mostrar();

            var id = prompt("Ingrese el id de la pelicula: ");
            var Genero = prompt("Ingrese el genero: ");
            var Fecha = prompt("Ingrese la fecha: ");
            var Nombre = prompt("Ingrese el nombre: ");
            
            Pelicula = new Pelicula(id,Genero,Fecha,Nombre);

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