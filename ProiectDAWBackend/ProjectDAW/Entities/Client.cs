using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public Adresa Adresa { get; set; }
        public ICollection<Comanda> Comenzi { get; set; }

    }
}
