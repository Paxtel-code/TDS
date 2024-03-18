using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutosEFCore.Data;
using Produtos.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APiComEFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {

        private readonly ProdutosContext _context;

        public TodoItemController(ProdutosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  ActionResult<List<ProdutosModel>> Produtos() {
            // return Created();
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel?>> ProdutosById(long id) {
            // return Created();
            // return await _context.TodoItems.Where(i => i.TodoItemID.Equals(id)).SingleOrDefaultAsync();
            return await _context.TodoItems.Where(i => i.Id.Equals(id)).FirstAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> Produtos(ProdutosModel todoItem) {
            _context.Add(todoItem);
            await _context.SaveChangesAsync();

            // return Created();
            return CreatedAtAction("ItemTodo", todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Produtos(long id, ProdutosModel todoItem) {
            if (id != todoItem.Id) {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            // return Created();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutosModel>> ProdutosDelete(long id) {
            var todoItem =await ProdutosById(id);
            _context.Remove<ProdutosModel>(todoItem.Value!);
            await _context.SaveChangesAsync();

            // return Created();
            return Ok();
        }
    }

}