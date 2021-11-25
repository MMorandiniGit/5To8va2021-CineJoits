using System;
using MenuesConsola;
using AdminConsola.Menu;
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
            var adoAGBD = FactoryAdoMySQL.GetAdoDesdeJson("appSettings.json", "admin");
            Ado= new AdoCine(adoAGBD);

            var menuListaSalas = new MenuListaSalas() { Nombre = "Listado Salas" };
            var menuAltaSala = new MenuAltaSala(menuListaSalas);

            var menuSala = new MenuCompuesto(){ Nombre = "Salas" };
            menuSala.agregarMenu(menuListaSalas);
            menuSala.agregarMenu(menuAltaSala);

            var menuInicial = new MenuCompuesto() {Nombre = "Menu Admin"};
            menuInicial.agregarMenu(menuSala);
        }
    }
}
