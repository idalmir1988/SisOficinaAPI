using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaAPI.Data;
using OficinaAPI.Models;

namespace OficinaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository _repo;

        public ClienteController(IRepository repo)
        {
            _repo = repo;
        }

        //[HttpPost]
        public IActionResult CadastraCliente(Cliente cliente)
        {
            _repo.Add(cliente);
            if (_repo.SaveChanges())
            {
                return Created($"api/cliente/{cliente.Id}", cliente);
            }
            return BadRequest("Cliente não cadastrado");

        }

        // GET: api/Cliente
        [HttpGet]
        public IActionResult RecuperaClientes()
        {
            var result = _repo.GetAllClientes();
            return Ok(result);
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public IActionResult RecuperaClientesPorId(int id)
        {
            Cliente cliente = _repo.GetClienteById(id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound("Cliente não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] Cliente model)
        {
            Cliente cliente = _repo.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound("Registro não atualizado");
            }

            _repo.Update(model);
            if (_repo.SaveChanges())
            {
                return Created($"api/cliente/{cliente.Id}", model);
            }
            return BadRequest("Cliente não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id, [FromBody] Cliente model)
        {
            Cliente cliente = _repo.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound("Erro ao deletar");
            }
            
            _repo.Delete(cliente);
            if (_repo.SaveChanges())
            {
                return Ok("Cliente Deletado");
            }
            return BadRequest("Erro ao deletar cliente");
        }
    }
}
