using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDAW.Entities;
using ProjectDAW.Entities.DTOs;
using ProjectDAW.Repositories.ComandaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaRepository _repository;
        public ComandaController(IComandaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComandaById(int id)
        {
            var comanda = await _repository.GetByIdAsync(id);

            if (comanda == null)
            {
                return NotFound("Comanda cu id-ul dat nu exista!");
            }

            return Ok(new ComandaDTO(comanda));
        }

        [HttpPost]
        public async Task<IActionResult> CreateComanda(CreateComandaDTO dto)
        {
            Comanda comandaNoua = new Comanda();

            comandaNoua.Valoare = dto.Valoare;
            comandaNoua.TipPlata = dto.TipPlata;
            comandaNoua.DataPlasare = dto.DataPlasare;
            comandaNoua.ClientId = dto.ClientId;

            _repository.Create(comandaNoua);

            await _repository.SaveAsync();

            return Ok(new ComandaDTO(comandaNoua));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComanda(int id)
        {
            var comanda = await _repository.GetByIdAsync(id);

            if (comanda == null)
            {
                return NotFound("Comanda nu exista!");
            }

            _repository.Delete(comanda);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComanda([FromBody] Comanda comanda)
        {
            var comandaCurenta = await _repository.GetByIdAsync(comanda.Id);
            comandaCurenta.Valoare = comanda.Valoare;
            comandaCurenta.TipPlata = comanda.TipPlata;
            comandaCurenta.DataPlasare = comanda.DataPlasare;

            if (comandaCurenta == null)
            {
                return NotFound("Comanda nu exista!");
            }

            _repository.Update(comandaCurenta);

            await _repository.SaveAsync();

            return Ok();
        }
    }
}
