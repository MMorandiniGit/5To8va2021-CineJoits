using System.Collections.Generic;

namespace Cine.Core
{
    public interface IAdo
    {
        void AltaPelicula(Pelicula pelicula);
        void AltaSala(Sala sala);
        void AltaCliente(Cliente cliente);
        List<Sala> ObtenerSalas();
        List<Pelicula> ObtenerPeliculas();
        List<Proyeccion> ObtenerProyecciones();
        List<Cliente> ObtenerClientes();
    }
}