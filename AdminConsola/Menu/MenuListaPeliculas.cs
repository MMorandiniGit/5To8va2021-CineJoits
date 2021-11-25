using System;
using et12.edu.ar.MenuesConsola;
using Cine.Core;
using System.Collections.Generic;

namespace AdminConsola.Menu
{
    public class MenuListaPeliculas : MenuListador<Pelicula>
    {
        public override void imprimirElemento(Pelicula Pelicula)
        {
            Console.WriteLine($"{peliculas.Id}\t\t{peliculas.Genero}\t\t{peliculas.Fecha}\t\t{peliculas.Nombre}");
        }

        public override List<Pelicula> obtenerLista() => Program.Ado.ObtenerPeliculas();
    }
}