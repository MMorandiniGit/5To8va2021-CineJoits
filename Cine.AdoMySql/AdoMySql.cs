using System;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using System.Collections.Generic;

namespace Cine.AdoMySql
{
    public class AdoMySql : IAdo
    {
        public MapSala MapSala { get; set; }

        public MapPelicula MapPelicula { get; set; }
        public void AltaPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public void AltaSala(Sala sala)
        {
            MapSala.AltaSala(sala);
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            throw new ()NotImplementedException;
        }

        public List<Sala> ObtenerSalas()
        {
            return MapSala.ObtenerSalas();
        }
    }
}
