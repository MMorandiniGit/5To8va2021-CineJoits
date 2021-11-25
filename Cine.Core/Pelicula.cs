using System;
using System.Collections.Generic;

namespace Cine.Core
{
    public class Pelicula
    {
        private object genero;

        public short Id { get; set;}
        public string Genero { get; set;}
        public DateTime Fecha { get; set;}
        public string Nombre { get; set;}
        public List<int> HistorialP { get; set; }

        public Pelicula()
        {
            List<int> HistorialP = new List<int>();
        }

        public Pelicula(string genero, DateTime fecha, string nombre)
        {
            Genero = genero;
            Fecha = fecha;
            Nombre = nombre;
        }
    }
}
