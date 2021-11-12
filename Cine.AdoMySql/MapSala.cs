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
            piso=fila["piso"].ToString(),
            capacidad=Convert.toshort(fila["capacidad"]),
        };
        public void AltaSala(Sala sala)
        =>EjecutarComandoCon("altaSala", ConfigurarAltaSala, PostAltaSala, sala);
        public void ConfigurarAltaSala(Sala sala)
        {
            SetComandoSP("altaSala");

            BD.CrearParametroSalida("unidsala")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .AgregarParametro();

            BP.CrearParametro("unaSala")
              .SetTipoVarchar(45)
              .SetValor(sala.Nombre)
              .AgregarParametro();
        }
        public void PostAltaSala(Sala sala)
        {
            var paramIdSala=GetParametro("unaIdSala");
            rubro.Id=Convert.ToByte(paramIdSala.Value);
        }
        internal List<Sala> ObtenerSalas() => ColeccionDesdeTabla();
    }
}