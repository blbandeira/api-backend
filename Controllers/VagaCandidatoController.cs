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
    public class VagaCandidatoController : ControllerBase
    {
        private readonly IVagaCandidatoRepository _repo;

        public VagaCandidatoController(IVagaCandidatoRepository Repo)
        {
            _repo = Repo;
        }

        // GET: api/VagaCandidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaga_Candidato>>> GetVagaCandidato()
        {
           
            try
            {
                Task<Vaga_Candidato[]> candidatos;
                candidatos = _repo.GetAllVagaCandidato();
                return await candidatos;
            }
            catch 
            {
                return BadRequest("Erro");
            }
        }

        // GET: api/VagaCandidato/5
        [HttpGet("{id}")]
        public  ActionResult<Vaga_Candidato> GetVagaCandidato(int id)
        {
            try{
            var candidatura = _repo.GetVagaCandidatoAsyncById(id);

            return Ok(candidatura);
            }
            catch {
                return BadRequest("Erro");
            }
        }

        
        // POST: api/VagaCandidato
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vaga_Candidato>> PostVagaCandidato(Vaga_Candidato vagaCandidato)
        {
            vagaCandidato.Dt_Candidatura = DateTime.Now;
            
            _repo.add(vagaCandidato);

            if (await _repo.SaveChangesAsync() ) { return Ok(vagaCandidato) ;}

            return BadRequest("Não foi possivel salvar");
        }
    }
}
