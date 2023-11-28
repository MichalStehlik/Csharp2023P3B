using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C02EFC.Models
{
    internal class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Company? Developer { get; set; } // map property N:1
        public int DeveloperId { get; set; } // cizí klíč
    }
}
