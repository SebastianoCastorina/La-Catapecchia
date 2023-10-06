using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Catapecchia.Models
{
    public class Utente
    {
        public int IdUser { get; set; }
         public string Username { get; set; }
        public string Password { get; set; }
        public string Ruolo { get; set; }
    }
}