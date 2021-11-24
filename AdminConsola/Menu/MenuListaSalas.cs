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
            Console.WriteLine($"{salas.Id}\t\t{salas.Piso}\t\t{salas.Capacidad}");
        }

        public override List<Cajero> ObtenerSalas() => Program.Ado.ObtenerSalas();
        
    }
}