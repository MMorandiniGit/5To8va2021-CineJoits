using System;
using Cine.Core;
using et12.edu.ar.MenuesConsola;

namespace AdminConsola.Menu
{
    public class MenuAltaCliente : MenuComponente
    {
        private Cliente Cliente {get;set;}
        public MenuAltaCliente()
        {
            Nombre = "Alta Cliente";
        }
        public override void mostrar()
        {
            base.mostrar()
        }
    }
}