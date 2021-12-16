using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;


namespace AdminConsola.Menu
{
    public class MenuAltaSala : MenuComponente
    {
        private Sala Sala { get; set; }

        public MenuAltaSala():base("Alta sala")
        {
            Nombre = "Alta Sala";
        }

        public override void mostrar()
        {
            base.mostrar();

            var piso = sbyte.Parse(prompt("Ingrese el piso de la sala"));
            var capacidad = ushort.Parse(prompt("Ingrese la capacidad"));

            Sala = new Sala(piso, capacidad);

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