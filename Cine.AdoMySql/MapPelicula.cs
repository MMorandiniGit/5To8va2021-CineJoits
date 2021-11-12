using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Cine.AdoMySql
{
    public class MapPelicula : Mapeador<Pelicula>
    {
        public MapPelicula(AdoAGBD ado):base(ado)
        {
            Tabla = "Pelicula";
        }
        public override Pelicula ObjetoDesdeFila(DataRow fila)
        {
            throw new NotImplementedException();
        }
    }
}