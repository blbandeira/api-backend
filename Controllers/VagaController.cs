using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_backend.Models;
using api_backend.Data;

namespace api_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : ControllerBase
    {
        private readonly IVagaRepository _repo;
  
        public VagaController(IVagaRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Vaga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaga>>> GetVaga()
        {
            return await _repo.GetAllVagas(true);
        }

        // GET: api/Vaga/5
        [HttpGet("{id}")]
        public ActionResult<Vaga> GetVaga(int id)
        {
         
        try {
           var vaga =   _repo.GetVagaAsyncById(id);

           if (vaga == null) {return NotFound();}
            
            return vaga;
            }
        catch 
        {
            return BadRequest();
        }

        }


    [HttpPost]

    public async Task<ActionResult<Vaga>> Post (Vaga model)
    {  
        try {    
            model.Ativa = true;

            _repo.add(model);

            if (await _repo.SaveChangesAsync()) {return Ok(model);}
            
            return BadRequest("Não foi possivel salvar no BD");
            }
        catch {
            return BadRequest("Erro");
        }
    }



        // PUT: api/Vaga/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaga(int id, Vaga vaga)
        {
            if (vaga.Id != id) {return BadRequest("Id inválido");}

            _repo.Update(vaga);

            if (await _repo.SaveChangesAsync()) { return Ok(vaga);}

            return BadRequest("Não foi possivel salvar no BD");
        }
/*
        // POST: api/Vaga
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vaga>> PostVaga(Vaga vaga)
        {
            _context.Vaga.Add(vaga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaga", new { id = vaga.Id }, vaga);
        }

        // DELETE: api/Vaga/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vaga>> DeleteVaga(int id)
        {
            var vaga = await _context.Vaga.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }

            _context.Vaga.Remove(vaga);
            await _context.SaveChangesAsync();

            return vaga;
        }

        private bool VagaExists(int id)
        {
            return _context.Vaga.Any(e => e.Id == id);
        }
    */
    }

}
