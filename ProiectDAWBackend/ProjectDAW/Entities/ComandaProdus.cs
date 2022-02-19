using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities
{
    public class ComandaProdus
    {
        public int ComandaId { get; set; }
        public Comanda Comanda { get; set; }
        public int ProdusId { get; set; }
        public Produs Produs { get; set; }
        public int Cantitate { get; set; }
    }
}
