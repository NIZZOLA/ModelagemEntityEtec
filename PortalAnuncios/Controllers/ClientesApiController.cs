﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelagemBd;
using PortalAnuncios.Data;

namespace PortalAnuncios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesApiController : ControllerBase
    {
        private readonly PortalAnunciosContext _context;
        public ClientesApiController(PortalAnunciosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetCliente()
        {
            var result = _context.Cliente.Include(a => a.Enderecos).ToList();
            return result;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
    }
}
