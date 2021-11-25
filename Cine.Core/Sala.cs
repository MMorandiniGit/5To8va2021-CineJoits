using System;

namespace Cine.Core
{
    public class Sala
    {
        public sbyte Id { get; set;}
        public sbyte Piso { get; set;}
        public ushort Capacidad { get; set;}

        public Sala(){}

        public Sala(sbyte piso, ushort capacidad)
        {
            Piso = piso;
            Capacidad = capacidad;
        }
    }

}