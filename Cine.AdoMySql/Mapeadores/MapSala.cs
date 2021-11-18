using System;
using System.Collections.Generic;
using System.Data;
using Cine.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace Cine.AdoMySql.Mapeadores
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
            Id = Convert.ToSByte(fila["idSala"]),
            Piso = Convert.ToSByte(fila["Piso"]),
            Capacidad = Convert.ToUInt16(fila["Capacidad"]),
        };
        public void AltaSala(Sala sala)
        =>EjecutarComandoCon("altaSala", ConfigurarAltaSala, PostAltaSala, sala);
        public void ConfigurarAltaSala(Sala sala)
        {
            SetComandoSP("altaSala");

            BP.CrearParametroSalida("unidsala")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("unaSala")
              .SetTipoVarchar(45)
              .SetValor(sala.Capacidad)
              .AgregarParametro();
        }
        public void PostAltaSala(Sala sala)
        {
            var paramIdSala=GetParametro("unaIdSala");
            sala.Id = Convert.ToSByte(paramIdSala.Value);
        }
        internal List<Sala> ObtenerSalas() => ColeccionDesdeTabla();
    }
}