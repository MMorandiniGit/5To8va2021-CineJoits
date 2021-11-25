using System;
using System.Collections.Generic;

namespace Cine.Core
{
    public class Proyeccion
    {
        public short Id { get; set;}
        public Sala Sala { get; set;}
        public Pelicula Pelicula { get; set;}
        public DateTime Fechahora { get; set;}

        public Proyeccion()
        {
            List<int> HistorialPro = new List<int>();
        }
    }
}