using System;
using et12.edu.ar.MenuesConsola;
using AdminConsola.Menu;
using Cine.Core;
using Cine;
using Cine.AdoMySql;
using et12.edu.ar.AGBD.Ado;

namespace AdminConsola
{
    public class Program
    {
        public static IAdo Ado {get; private set;}
        static void Main(string[] args)
        {
            var adoAGBD = FactoryAdoMySQL.GetAdoMySQL("appSettings.json", "admin");
            Ado= new AdoCine(adoAGBD);

            var menuListaSalas = new MenuListaSalas() { Nombre = "Listado Salas" };
            var menuAltaSala = new MenuAltaSala();

            var menuSala = new MenuCompuesto("Menu Sala", menuAltaSala, menuListaSalas);

            var menuInicial = new MenuCompuesto("Menu Admin", menuSala);

            menuInicial.Mostrar();
        }
    }
}
