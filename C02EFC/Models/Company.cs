using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C02EFC.Models
{
    internal class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Game>? Games { get; set; } // map property 1:N
    }
}
