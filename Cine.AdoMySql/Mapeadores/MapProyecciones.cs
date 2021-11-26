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

        public MapProyecciones(MapPelicula mapPelicula):this(mapPelicula.AdoAGBD)
            => MapPelicula = mapPelicula;

        public MapProyecciones(MapSala mapSala): this(mapSala.AdoAGBD)
            => MapSala = mapSala;

        public override Proyeccion ObjetoDesdeFila(DataRow fila)
            => new Proyeccion()
            {
                Sala = MapSala.SalaPorId(Convert.ToSByte(fila["id"])),
                Pelicula =  MapPelicula.PeliculaPorId(Convert.ToString(fila["nombre"])),
                Fechahora = Convert.ToDateTime(fila["fechaHora"])
            };
        public List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
    }
}