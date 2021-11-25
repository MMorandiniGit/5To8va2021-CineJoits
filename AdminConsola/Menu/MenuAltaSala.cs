using System;
using MenuesConsola;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminConsola.Menu
{
    public class MenuAltaSala : MenuCompuesto
    {
        private Sala Sala { get; set; } 


        public override void mostrar()
        {
            base.mostrar();

            var id = prompt("Ingrese el id de la sala");
            var piso = prompt("Ingrese el piso de la sala");
            var capacidad = prompt("Ingrese la capacidad");

            Sala = new Sala(Piso, Capacidad);

            try
            {
                Program.Ado.AltaSala(Sala);
                Console.WriteLine("Se dio de alta la sala correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo dar de alta la sala: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}