using Cine.Core;
using Cine.AdoMySql.Mapeadores;
using System.Collections.Generic;

namespace Cine.AdoMySql
{
    public class AdoMySql : IAdo
    {
        public MapSala MapSala { get; set; }

        public MapPelicula MapPelicula { get; set; }
        public void AltaPelicula(Pelicula pelicula)
        {
            MapPelicula.AltaPelicula(pelicula);
        }

        public void AltaSala(Sala sala)
        {
            MapSala.AltaSala(sala);
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            return MapPelicula.ObtenerPeliculas();
        }

        public List<Sala> ObtenerSalas()
        {
            return MapSala.ObtenerSalas();
        }
    }
}
