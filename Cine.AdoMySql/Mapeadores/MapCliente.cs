using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cine.AdoMySql.Mapeadores
{
    public class MapCliente : Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente()
        {
            Id = Convert.ToByte(fila["idPelicula"]),
            Nombre = fila["nombre"].ToString(),
            Apellido = fila["apellido"].ToString(),
            Mail = fila["mail"].ToString()
        };

    }
}