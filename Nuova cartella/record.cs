using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grossetapp.Nuova_cartella
{
    public class Record
    {
        public string Stato { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }
        public string Sindaco { get; set; }
        public Coordinate Coordinate { get; set; }
        public int Altitudine { get; set; }
        public string Superficie { get; set; }
        public string Abitanti { get; set; }
        public string Densit { get; set; }
        public string Stemma { get; set; }
    }
}