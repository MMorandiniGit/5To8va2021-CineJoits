using System;

namespace Cine.Core
{
    public class Proyeccion
    {
        public short Id { get; set;}
        public Sala Sala { get; set;}
        public Pelicula Pelicula { get; set;}
        public DateTime Fechahora { get; set;}
    }
}