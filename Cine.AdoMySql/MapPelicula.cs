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
            => new Pelicula()
        {
            Id = Convert.ToByte(fila["idPelicula"]),
            Nombre = fila["Pelicula"].ToString()
        };

        public void AltaPelicula(Pelicula pelicula)
            => EjecutarComandoCon("altaPelicula", ConfigurarAltaPelicula, PostAltaPelicula, pelicula);
        public void ConfigurarAltaPelicula(Pelicula pelicula)
        {
            SetComandoSP("altaPelicula");

            BP.CrearParametroSalida("unidPelicula")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .AgregarParametro();

            BP.CrearParametro("unaPelicula")
              .SetTipoVarchar(45)
              .SetValor(pelicula.Nombre)
              .AgregarParametro();
        }

        public void PostAltaPelicula(Pelicula pelicula)
        {
            var paramIdPelicula = GetParametro("unidPelicula");
            pelicula.Id = Convert.ToByte(paramIdPelicula.Value);
        }

        public List<Pelicula> ObtenerPeliculas() => ColeccionDesdeTabla();
    }
}