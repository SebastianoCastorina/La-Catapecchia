using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Catapecchia.Models
{
    public class ServiziPerPrenotazione
    {
        public int IdServiziPerPrenotazione { get; set; }
    public DateTime Data {  get; set; }
        public int  Quantità { get; set; }
        public int IdServizio { get; set; }
        public int IdPrenotazione { get; set; }

    }
}