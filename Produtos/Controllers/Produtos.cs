using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutosEFCore.Data;
using Produtos.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProdutosEFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {

        private readonly ProdutosContext _context;

        public ProdutosController(ProdutosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ProdutosModel>> Produtos()
        {
            return _context.Produtos.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel?>> ProdutosById(int id)
        {
            var produto = await _context.Produtos.Where(i => i.Id == id).FirstAsync();
            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> Produtos(ProdutosModel Produto)
        {
            _context.Add(Produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Produtos", Produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Produtos(int id, ProdutosModel Produto)
        {
            if (id != Produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(Produto).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutosModel>> ProdutosDelete(int id)
        {
            var Produto = await ProdutosById(id);
            if (Produto == null)
            {
                return BadRequest();
            }
            _context.Remove<ProdutosModel>(Produto.Value!);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}