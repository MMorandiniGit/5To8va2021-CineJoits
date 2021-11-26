using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using System.Collections.Generic;
using System.Data;
using System;

namespace Cine.AdoMySql.Mapeadores
{
    public class MapProyecciones : Mapeador<Proyeccion>
    {
        public MapPelicula MapPelicula { get; set; }
        public MapSala MapSala { get; set; }

        public MapProyecciones(AdoAGBD ado):base(ado)
        {
            Tabla = "Proyeccion";
        } 

        public MapProyecciones(MapPelicula mapPelicula, MapSala mapSala): this(mapSala.AdoAGBD)
        {
            MapPelicula = mapPelicula;
            MapSala = mapSala;
        }

        public override Proyeccion ObjetoDesdeFila(DataRow fila)
            => new Proyeccion()
            {
                Sala = MapSala.SalaPorId(Convert.ToSByte(fila["idsala"])),
                Pelicula =  MapPelicula.PeliculaPorId(Convert.ToString(fila["idPelicula"])),
                Fechahora = Convert.ToDateTime(fila["fechaHora"])
            };
        public List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
    }
}