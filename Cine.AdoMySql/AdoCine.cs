using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using Cine.AdoMySql.Mapeadores;

namespace Cine.AdoMySql
{
    public class AdoCine
    {
        public AdoAGBD Ado { get; set; }
        public MapPelicula MapPelicula { get; set; }
        public AdoCine(AdoAGBD ado)
        {
            Ado = ado;
            MapPelicula = new MapPelicula(ado);
        }
        public void altaPelicula(Pelicula pelicula) => MapPelicula.AltaPelicula(pelicula);
        public List<Pelicula> ObtenerPelicula() => MapPelicula.ObtenerPeliculas();
    }
}