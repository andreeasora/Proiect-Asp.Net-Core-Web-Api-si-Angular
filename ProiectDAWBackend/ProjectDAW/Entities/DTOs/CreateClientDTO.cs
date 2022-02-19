using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities.DTOs
{
    public class CreateClientDTO
    {
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public Adresa Adresa { get; set; }

    }
}
