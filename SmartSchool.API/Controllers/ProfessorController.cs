
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        public ProfessorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("puuuts");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor){
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor){
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("puuts");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor){
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Puuuts");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado");
            _context.Remove(professor);
            _context.SaveChanges();
            return Ok(professor);
            
        }

    }
}