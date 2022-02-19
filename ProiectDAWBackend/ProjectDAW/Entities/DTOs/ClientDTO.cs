using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public Adresa Adresa { get; set; }
        public List<Comanda> Comenzi { get; set; }

        public ClientDTO(Client client)
        {
            this.Id = client.Id;
            this.Nume = client.Nume;
            this.Telefon = client.Telefon;
            this.Adresa = client.Adresa;
            this.Comenzi = new List<Comanda>();
        }
    }
}
