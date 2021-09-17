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
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        public IActionResult CadastraCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            
            if (_context.SaveChanges() > 0)
            {
                return Created($"api/cliente/{cliente.Id}", cliente);
            }
            return BadRequest("Cliente não cadastrado");
            
        }

        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<Cliente> RecuperaClientes()
        {
            return _context.Clientes;
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public IActionResult RecuperaClientesPorId(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound("Cliente não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] Cliente model)
        {
            //_context.Clientes.Update(model);
            //_context.SaveChanges();
            //return Ok(model);

            Cliente cliente = _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _context.Clientes.Update(model);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound("Registro não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id, [FromBody] Cliente model)
        {
            Cliente cliente = _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound("Erro ao deletar");
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        //{
        //    return await _context.Clientes.ToListAsync();
        //}

        // GET: api/Cliente/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Cliente>> GetCliente(int id)
        //{
        //    var cliente = await _context.Clientes.FindAsync(id);

        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return cliente;
        //}

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        //{
        //    if (id != cliente.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cliente).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClienteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        //{
        //    _context.Clientes.Add(cliente);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        //}

        // DELETE: api/Cliente/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCliente(int id)
        //{
        //    var cliente = await _context.Clientes.FindAsync(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clientes.Remove(cliente);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ClienteExists(int id)
        //{
        //    return _context.Clientes.Any(e => e.Id == id);
        //}
    }
}
