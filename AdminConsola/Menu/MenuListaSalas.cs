using System;
using et12.edu.ar.MenuesConsola;
using Cine.Core;
using System.Collections.Generic;

namespace AdminConsola.Menu
{
    public class MenuListaSalas : MenuListador<Sala>
    {
        public override void imprimirElemento(Sala salas)
        {
            Console.WriteLine($"N°:{salas.Id}\t\tPiso: {salas.Piso}\t\tCapacidad: {salas.Capacidad}");
        }

        public override List<Sala> obtenerLista() => Program.Ado.ObtenerSalas();
    }
}