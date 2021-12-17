using System;
using et12.edu.ar.MenuesConsola;
using Cine.Core;
using System.Collections.Generic;

namespace AdminConsola.Menu
{
    public class MenuListaClientes : MenuListador<Cliente>
    {
        public override void imprimirElemento(Cliente cliente)
        {
            Console.WriteLine($"N°: {cliente.Id}\t Nombre: {cliente.Nombre}\t Apellido: {cliente.Apellido}\t Mail: {cliente.Mail}\t Pass: {cliente.Pass}");
        }
        public override List<Cliente> obtenerLista() => Program.Ado.ObtenerClientes();
    }
}