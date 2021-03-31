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
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoRepository _repo;

        public CandidatoController(ICandidatoRepository Repo)
        {
            _repo = Repo;
        }
      

        // GET: api/Candidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidato()
        {
           
            try
            {
                Task<Candidato[]> candidatos;
                candidatos = _repo.GetAllCandidatos();
                return await candidatos;
            }
            catch 
            {
                return BadRequest("Erro");
            }
            
            //return await _context.Candidato.ToListAsync();
        }

        // GET: api/Candidato/5
        [HttpGet("{id}")]
        public  ActionResult<Candidato> GetCandidato(int id)
        {
            try 
            {
                var candidato = _repo.GetCandidatoAsyncById(id);

                if (candidato == null){return NotFound();}
                
                return candidato;
            }
            catch 
            {
                return BadRequest();
            }

        }


        [HttpPost] 
        public async Task<IActionResult> Post(Candidato model) 
        {
            try {


                model.Data_Cadastro = DateTime.Now;

                _repo.add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }   
            } 
            catch {
                return BadRequest("Erro");
            }

            return BadRequest("Erro nao esperado") ;
        }

        // PUT: api/Candidato/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato(int id, Candidato model)
        {  
            
            try 
            {
                
                var confid = model.Id;
                
                if (id != confid) {return BadRequest("Id invalido");}
                
                _repo.Update(model);

                if (await _repo.SaveChangesAsync()) 
                {
                    return  Ok(model);
                }
                return BadRequest("erro");
            }
            catch 
            {
                return BadRequest();
            }

        }

    } 

   
    
} 
