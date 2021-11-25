using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using System.Collections.Generic;
using System.Data;

namespace Cine.AdoMySql.Mapeadores
{
    public class MapProyecciones : Mapeador<Proyeccion>
    {
        public MapPelicula MapPelicula { get; set; }
        public MapSala MapSala { get; set; }
        public override Proyeccion ObjetoDesdeFila(DataRow fila)
            => new Proyeccion()
            {
                //TODO MapSala.SalaPorId()devuelve sala
                //TODO MapPelicula.peliPorId() devuelve una peli
                Fechahora = Convert.ToDateTime(fila["fechaHora"])
            };

        public MapProyecciones(AdoAGBD ado):base(ado)
        {
            Tabla = "Proyeccion";
        }
        internal List<Proyeccion> ObtenerProyecciones() => ColeccionDesdeTabla();
    }
}