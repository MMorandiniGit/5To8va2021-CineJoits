using System;
using MenuesConsola;
using Cine.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminConsola.Menu
{
    public class MenuListaSalas : MenuListador<Sala>
    {
        public override void imprimirElemento(Sala salas)
        {
            Console.WriteLine($"N°:{salas.Id}\t\tPiso: {salas.Piso}\t\tCapacidad: {salas.Capacidad}");
        }

        public override List<Cajero> ObtenerSalas() => Program.Ado.ObtenerSalas();
    }
}