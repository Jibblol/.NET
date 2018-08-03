using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GameAPI.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly WhatsThatGameProdContext _context;

        public TodoController(WhatsThatGameProdContext context)
        {
            _context = context;

            if (!_context.Game.Any()) {
                //_context.Game.Add(new Game { Title = "TPA" , Description = "Pinball game" ,  Year = 2013});
                //_context.Game.Add(new Game { Title = "KCD" , Description = "Medieval game", Year = 2018 });
                //_context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return _context.Game.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(int id)
        {
            var item = _context.Game.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Game item)
        {
            _context.Game.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Game item)
        {
            var todo = _context.Game.Find(id);
            if (todo == null) {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Title = item.Title;

            _context.Game.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Game.Find(id);
            if (todo == null) {
                return NotFound();
            }

            _context.Game.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}