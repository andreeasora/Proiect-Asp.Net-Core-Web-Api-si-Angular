using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities.DTOs
{
    public class CreateComandaDTO
    {
        public int Valoare { get; set; }
        public string TipPlata { get; set; }
        public string DataPlasare { get; set; }
        public int ClientId { get; set; }
    }
}
