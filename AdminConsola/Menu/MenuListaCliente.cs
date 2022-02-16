using System;
using et12.edu.ar.MenuesConsola;
using Cine.Core;
using System.Collections.Generic;
using AdminConsola;

namespace ClienteConsola.Menu
{
    public class MenuListaClientes : MenuListador<Cliente>
    {
        public override void imprimirElemento(Cliente cliente)
        {
            Console.WriteLine($"N°: {cliente.Id}\t Nombre: {cliente.Nombre}\t Apellido: {cliente.Apellido}\t Mail: {cliente.Mail}\t  {cliente.Pass}");
        }
        public override List<Cliente> obtenerLista() => Program.Ado.ObtenerClientes();
    }
}