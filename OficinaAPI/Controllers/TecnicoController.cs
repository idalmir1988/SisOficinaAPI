using Microsoft.AspNetCore.Mvc;
using OficinaAPI.Data;
using OficinaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly IRepository _repo;

        public TecnicoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult RecuperaTecnicos()
        {
            var result = _repo.GetAllTecnicos();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CadastraTecnico(Tecnico tecnico) 
        {
            _repo.Add(tecnico);
            if (_repo.SaveChanges())
            {
                return Created($"api/tecnico/{tecnico.Id}", tecnico);
            }
            return BadRequest("Erro ao cadastrar um novo técnico.");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaTecnico(int id, [FromBody] Tecnico model) 
        {
            var result = _repo.GetTecnicoById(id);
            if (result == null)
            {
                return BadRequest("Técnico não foi encontrado");
            }

            _repo.Update(model);
            if (_repo.SaveChanges())
            {
                return Created($"api/tecnico/{model.Id}", model);
            }
            return BadRequest("Erro ao atualizar técnico");
        }

        [HttpDelete]
        public IActionResult DeletaTecnico(int id, [FromBody] Tecnico model)
        {
            var result = _repo.GetTecnicoById(id);
            if (result == null)
            {
                return BadRequest("Técnico não foi encontrado");
            }

            _repo.Delete(model);
            if (_repo.SaveChanges())
            {
                return Created($"api/tecnico/{result.Id}", model);
            }

            return BadRequest("Erro ao excluir o técnico.");
        }
    }
}
