using System.Collections.Generic;

namespace Cine.Core
{
    public interface IAdo
    {
        void AltaPelicula(Pelicula pelicula);
        void AltaSala(Sala sala);
        List<Sala> ObtenerSalas();
        List<Pelicula> ObtenerPeliculas();
    }
}