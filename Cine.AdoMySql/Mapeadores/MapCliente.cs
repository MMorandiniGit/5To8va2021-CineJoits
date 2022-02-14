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
            Id = Convert.ToByte(fila["idCliente"]),
            Nombre = fila["nombre"].ToString(),
            Apellido = fila["apellido"].ToString(),
            Mail = fila["mail"].ToString()
        };
        public void AltaCliente(Cliente cliente)
        => EjecutarComandoCon("registrarcliente",ConfigurarAltaCliente, PostAltaCliente, cliente);
        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("registrarcliente");

            BP.CrearParametroSalida("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .AgregarParametro();

            BP.CrearParametro("unnombre")
              .SetValor(cliente.Nombre)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro();

            BP.CrearParametro("unapellido")
              .SetValor(cliente.Apellido)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro();

             BP.CrearParametro("unmail")
              .SetValor(cliente.Mail)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro(); 

              BP.CrearParametro("unpass")
              .SetValor(cliente.Pass)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro();
        }

        internal Cliente IngresarCliente(string mail, string pass)
        {
            SetComandoSP("Ingresar cliente");

              BP.CrearParametro("unmail")
              .SetValor(Cliente.mail)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro();

              BP.CrearParametro("unpass")
              .SetValor(Cliente.pass)
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.VarChar)
              .AgregarParametro();
        }

        internal Cliente ClientePorId(string id)
        {
            SetComandoSP("ClientePorId");

            BP.CrearParametro("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .SetValor(id)
              .AgregarParametro();

            return ElementoDesdeSP();  
        }

        public void PostAltaCliente(Cliente cliente)
        {
            var paramIdCliente = GetParametro("unidCliente");
            cliente.Id = Convert.ToByte(paramIdCliente.Value);
        }
        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
}