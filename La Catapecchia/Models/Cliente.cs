using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Catapecchia.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string CF { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Città {  get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }    
        public string Cellulare { get; set; }

    }
}