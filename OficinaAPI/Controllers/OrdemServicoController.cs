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
    public class OrdemServicoController : ControllerBase
    {
        private readonly IRepository _repo;

        public OrdemServicoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult RecuperaOrdens()
        {
            var result = _repo.GetOrdensServicos();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaOrdemServicoPorId(int id)
        {
            var ordemServico = _repo.GetOrdemServicoById(id);

            if (ordemServico != null)
            {
                return Ok(ordemServico);
            }
            return BadRequest("Ordem de serviço não encontrada");
        }

        [HttpPost]
        public IActionResult CadastraOrdem(OrdemServico ordemServico)
        {
            _repo.Add(ordemServico);
            if (_repo.SaveChanges())
            {
                return Created($"api/OrdemServico/{ordemServico.Id}", ordemServico);
            }
            return BadRequest("Erro ao cadastrar ordem de serviço");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaOrdem(int id, [FromBody] OrdemServico model)
        {
            var ordemServico = _repo.GetOrdemServicoById(id);
            if (ordemServico == null)
            {
                return BadRequest("Não foi possível localizar a ordem de servico de número: " + id);
            }

            _repo.Update(model);
            if (_repo.SaveChanges())
            {
                return Created($"api/ordemServico/{ordemServico.Id}", model);
            }
            return BadRequest("Erro ao atualizar a ordem de serviço de número: " + id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaOrdem(int id, [FromBody] OrdemServico model) 
        {
            var ordemServico = _repo.GetOrdemServicoById(0);
            if (ordemServico == null)
            {
                return BadRequest("Ordem de serviço não localizada." + id);
            }

            _repo.Delete(ordemServico);
            if (_repo.SaveChanges())
            {
                return Ok("Ordem de serviço deletada com sucesso.");
            }
            return BadRequest("Erro ao deletar a ordem de serviço de número: " + id);
        }
    }
}
