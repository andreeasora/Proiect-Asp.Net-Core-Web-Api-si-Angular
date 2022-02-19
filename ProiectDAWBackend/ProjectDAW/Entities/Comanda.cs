using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities
{
    public class Comanda
    {
        public int Id { get; set; }
        public int Valoare { get; set; }
        public string TipPlata { get; set; } ///cash/card
        public string DataPlasare { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } ///proprietate de navigare
        public ICollection<ComandaProdus> ComandaProduse { get; set; }
    }
}
