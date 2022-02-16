using System;
using et12.edu.ar.MenuesConsola;
using ClienteConsola.Menu;
using Cine.Core;
using Cine;
using Cine.AdoMySql;
using et12.edu.ar.AGBD.Ado;

namespace ClienteConsola
{
    public class Program
    {
        public static IAdo Ado {get; private set;}
        static void Main(string[] args)
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "cliente");
            Ado = new AdoCine(adoAGBD);
            var menuAltaCliente = new MenuAltaCliente();
            var menuIngresarCliente = new MenuIngresarCliente();
            var menuclientes = new MenuCompuesto("Menu cliente",menuAltaCliente, menuIngresarCliente);

            menuclientes.mostrar();
        }
    }
}