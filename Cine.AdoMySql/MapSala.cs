using System;
using System.Collections.Generic;
using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySql
{
    public class MapSala:Mapeador<Sala>
    {
        public MapSala(AdoAGBD ado):base(ado)
        {
            Tabla ="Sala";
        }

        public override Sala ObjetoDesdeFila(DataRow fila)
        => new Sala()
        {
            id=Convert.ToByte(fila["idSala"]),
            nombre=fila["sala"].ToString()
        };

        internal void AltaSala(Sala sala)
        {
            throw new NotImplementedException();
        }

        internal List<Sala> ObtenerSalas()
        {
            throw new NotImplementedException();
        }
    }
}