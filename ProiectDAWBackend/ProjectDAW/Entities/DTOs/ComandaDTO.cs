using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities.DTOs
{
    public class ComandaDTO
    {
        public int Id { get; set; }
        public int Valoare { get; set; }
        public string TipPlata { get; set; }
        public string DataPlasare { get; set; }
        public int ClientId { get; set; }
        public List<ComandaProdus> ComandaProduse { get; set; }

        public ComandaDTO(Comanda comanda)
        {
            this.Id = comanda.Id;
            this.Valoare = comanda.Valoare;
            this.TipPlata = comanda.TipPlata;
            this.DataPlasare = comanda.DataPlasare;
            this.ClientId = comanda.ClientId;
            this.ComandaProduse = new List<ComandaProdus>();
        }
    }
}
