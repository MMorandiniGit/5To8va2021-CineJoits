using System;
using MenuesConsola;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminConsola.Menu
{
    public class MenuAltaSala : MenuCompuesto
    {
        private MenuListaSalas MenuListaSalas { get; set; }  
        private Sala Sala { get; set; } 

        public MenuAltaSala(MenuListaSalas menuListaSalas)
        {
            MenuListaSalas = menuListaSalas;
            Nome = "Alta Sala";
        }
    }
}