using System;
using et12.edu.ar.MenuesConsola;
using Cine.Core;
using System.Collections.Generic;

namespace AdminConsola.Menu
{
    public class MenuListaPeliculas : MenuListador<Pelicula>
    {
        public override void imprimirElemento(Pelicula pelicula)
        {
            Console.WriteLine($"N°: {pelicula.Id}\t Genero: {pelicula.Genero}\t Fecha: {pelicula.Fecha}\t Nombre: {pelicula.Nombre}");
        }
        public override List<Pelicula> obtenerLista() => Program.Ado.ObtenerPeliculas();
    }
}