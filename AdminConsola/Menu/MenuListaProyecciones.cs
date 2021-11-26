using System;
using et12.edu.ar.MenuesConsola;
using Cine.Core;
using System.Collections.Generic;

namespace AdminConsola.Menu
{
    public class MenuListaProyecciones : MenuListador<Proyeccion>
    {
        public override void imprimirElemento(Proyeccion proyeccion)
        {
            Console.WriteLine($"N°: {proyeccion.Sala.Id}\t Nombre: {proyeccion.Pelicula.Nombre}\t Fecha: {proyeccion.Fechahora.ToShortDateString()}");
        }

        public override List<Proyeccion> obtenerLista() => Program.Ado.ObtenerProyecciones();
    }
}