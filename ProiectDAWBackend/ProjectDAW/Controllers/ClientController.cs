using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDAW.Data;
using ProjectDAW.Entities;
using ProjectDAW.Entities.DTOs;
using ProjectDAW.Repositories.ClientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly ProiectContext _context;
        public ClientController(IClientRepository repository, ProiectContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clienti = await _repository.GetAllClientsWithAdress();

            var clientiRezultat = new List<ClientDTO>();

            foreach (var client in clienti)
            {
                clientiRezultat.Add(new ClientDTO(client));
            }

            return Ok(clientiRezultat);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _repository.GetByIdWithAdress(id);

            if (client == null)
            {
                return NotFound("Clientul cu id-ul dat nu exista!");
            }

            return Ok(new ClientDTO(client));
        }

        [HttpGet("join")]
        public IActionResult GetJoin()
        {
            var clients = _context.Clienti;
            var join = _context.Comenzi.Join(clients, b => b.ClientId, a => a.Id, (b, a) => new
            {
                b.ClientId,
                b.Valoare,
                a.Nume
            }).ToList();

            return Ok(join);
        }

        [HttpGet("group-by")]
        public IActionResult GetGroupBy()
        {
            var valueAverage = _context.Comenzi.GroupBy(x => x.ClientId).Select(x => new
            {
                Key = x.Key,
                Average = x.Average(x => x.Valoare),
                Count = x.Count()
            }).ToList();

            return Ok(valueAverage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDTO dto)
        {
            Client clientNou = new Client();

            clientNou.Nume = dto.Nume;
            clientNou.Telefon = dto.Telefon;
            clientNou.Adresa = dto.Adresa;

            _repository.Create(clientNou);

            await _repository.SaveAsync();

            return Ok(new ClientDTO(clientNou));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient([FromBody] Client clientP)
        {
            var client = await _repository.GetByIdAsync(clientP.Id);

            if (client == null)
            {
                return NotFound("Clientul nu exista!");
            }

            _repository.Delete(client);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            var clientCurent = await _repository.GetByIdAsync(client.Id);
            clientCurent.Nume = client.Nume;
            clientCurent.Telefon = client.Telefon;

            if (clientCurent == null)
            {
                return NotFound("Clientul nu exista!");
            }

            _repository.Update(clientCurent);

            await _repository.SaveAsync();

            return Ok();
        }
    }
}

