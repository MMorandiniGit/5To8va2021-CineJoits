using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Cine.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cine.AdoMySql.Mapeadores
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
            Genero = fila["genero"].ToString(),
            Fecha = Convert.ToDateTime(fila["fecha"]),
            Nombre = fila["nombre"].ToString()
        };

        public void AltaPelicula(Pelicula pelicula)
            => EjecutarComandoCon("altaPelicula", ConfigurarAltaPelicula, PostAltaPelicula, pelicula);
        public void ConfigurarAltaPelicula(Pelicula pelicula)
        {
            SetComandoSP("altaPelicula");
            
            BP.CrearParametroSalida("unidPelicula")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .AgregarParametro();

            BP.CrearParametro("ungenero")
              .SetValor(pelicula.Genero)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro();

            BP.CrearParametro("unafecha")
              .SetValor(pelicula.Fecha)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
              .AgregarParametro();

            BP.CrearParametro("unnombre")
              .SetValor(pelicula.Nombre)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro();
        }

        internal Pelicula PeliculaPorId(string id)
        {
            SetComandoSP("PeliculaPorId");

            BP.CrearParametro("unidPelicula")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .SetValor(id)
              .AgregarParametro();

            return ElementoDesdeSP();  
        }

        public void PostAltaPelicula(Pelicula pelicula)
        {
            var paramIdPelicula = GetParametro("unidPelicula");
            pelicula.Id = Convert.ToByte(paramIdPelicula.Value);
        }        
        public List<Pelicula> ObtenerPeliculas() => ColeccionDesdeTabla();
    }
}