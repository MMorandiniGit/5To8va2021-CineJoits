using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using Cine.AdoMySql.Mapeadores;

namespace Cine.AdoMySql
{
    public class AdoCine: IAdo
    {
        public AdoAGBD Ado { get; set; }
        public MapPelicula MapPelicula { get; set; }
        public MapSala MapSala { get; set; }
        public AdoCine(AdoAGBD ado)
        {
            Ado = ado;
            MapPelicula = new MapPelicula(ado);
            MapSala = new MapSala(ado);
        }
        public void AltaPelicula(Pelicula pelicula) => MapPelicula.AltaPelicula(pelicula);
        public List<Pelicula> ObtenerPeliculas() => MapPelicula.ObtenerPeliculas();
        public void AltaSala(Sala sala) => MapSala.AltaSala(sala);
        public List<Sala> ObtenerSalas() =>MapSala.ObtenerSalas();
    }
}