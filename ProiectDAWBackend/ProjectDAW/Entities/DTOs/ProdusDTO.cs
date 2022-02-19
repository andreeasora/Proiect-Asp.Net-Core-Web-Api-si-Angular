using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities.DTOs
{
    public class ProdusDTO
    {
        public int Id { get; set; }
        public string NumeProdus { get; set; }
        public int Pret { get; set; }
        public List<ComandaProdus> ComandaProduse { get; set; }

        public ProdusDTO(Produs produs)
        {
            this.Id = produs.Id;
            this.NumeProdus = produs.NumeProdus;
            this.Pret = produs.Pret;
            this.ComandaProduse = new List<ComandaProdus>();
        }
    }
}
