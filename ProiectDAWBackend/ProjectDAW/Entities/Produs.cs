using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities
{
    public class Produs
    {
        public int Id { get; set; }
        public string NumeProdus { get; set; }
        public int Pret { get; set; }
        public ICollection<ComandaProdus> ComandaProduse { get; set; }

    }
}
