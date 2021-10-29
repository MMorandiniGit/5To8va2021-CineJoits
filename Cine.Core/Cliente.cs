using System;
using System.Collections.Generic;

namespace Cine.Core
{
    public class Cliente
    {
        public short Id { get; set;}
        public string Nombre { get; set;}
        public string Apellido { get; set;}
        public string Mail { get; set;}
        public string Pass { get; set;}
        public List<int> Historial { get; set; }
    }
}