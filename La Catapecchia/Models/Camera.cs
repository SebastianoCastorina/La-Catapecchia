using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Catapecchia.Models
{
    public class Camera
    {
        public int IdCamera { get; set; }
        public string DescrizioneCamera { get; set; }
        public bool Singola { get; set; }
        public double Prezzo { get; set; }
    }
}