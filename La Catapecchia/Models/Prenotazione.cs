using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Catapecchia.Models
{
    public class Prenotazione
    {
        public int IdPrenotazione{ get; set; }
public DateTime DataPrenotzione { get; set; }
        public DateTime Dal {  get; set; }
        public DateTime Al { get; set; }
        public double Caparra { get; set; } 
        public double Tariffa { get; set; }
        public bool MezzaPensione { get; set; }
        public bool PrimaColazione { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }

    }
}