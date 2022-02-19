using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDAW.Entities;
using ProjectDAW.Entities.DTOs;
using ProjectDAW.Repositories.ProdusRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdusController : ControllerBase
    {
        private readonly IProdusRepository _repository;
        public ProdusController(IProdusRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProdusByName(string name)
        {
            var produs =  await _repository.GetByName(name);

            if (produs == null)
            {
                return NotFound("Produsul cu numele dat nu exista!");
            }

            return Ok(new ProdusDTO(produs));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdus(CreateProdusDTO dto)
        {
            Produs produsNou = new Produs();

            produsNou.NumeProdus = dto.NumeProdus;
            produsNou.Pret = dto.Pret;

            _repository.Create(produsNou);

            await _repository.SaveAsync();

            return Ok(new ProdusDTO(produsNou));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdus(int id)
        {
            var produs = await _repository.GetByIdAsync(id);

            if (produs == null)
            {
                return NotFound("Produsul nu exista!");
            }

            _repository.Delete(produs);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProdus([FromBody] Produs produs)
        {
            var produsCurent = await _repository.GetByIdAsync(produs.Id);
            produsCurent.NumeProdus = produs.NumeProdus;
            produsCurent.Pret = produs.Pret;

            if (produsCurent == null)
            {
                return NotFound("Produsul nu exista!");
            }

            _repository.Update(produsCurent);

            await _repository.SaveAsync();

            return Ok();
        }
    }
}
