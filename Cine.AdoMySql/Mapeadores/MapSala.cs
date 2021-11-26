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
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
              .AgregarParametro();

            BP.CrearParametro("unpiso")
              .SetValor(sala.Piso)  
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
              .AgregarParametro();

            BP.CrearParametro("unacapacidad")
              .SetValor(sala.Capacidad)  
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .AgregarParametro();          
        }

        internal Sala SalaPorId(sbyte id)
        {
            SetComandoSP("SalaPorId");

            BP.CrearParametro("unidsala")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
              .SetValor(id)
              .AgregarParametro();
            
            return ElementoDesdeSP();
        }
        public void PostAltaSala(Sala sala)
        {
            var paramIdSala=GetParametro("unidsala");
            sala.Id = Convert.ToSByte(paramIdSala.Value);
        }
        public List<Sala> ObtenerSalas() => ColeccionDesdeTabla();
    }
}