using System.Linq;
using System.Threading.Tasks;
using api_backend.Models;
using Microsoft.EntityFrameworkCore;
using api_backend.Data;

namespace api_backend.Data
{
    public class CandidatoRepository : ICandidatoRepository
    {

        readonly MyDbContext _context;

        public CandidatoRepository(MyDbContext context)
        {
            _context = context;
        }
        public void add<Candidato>(Candidato candidato)
        {  

            
            _context.Add(candidato);
        }

        public void Update<Candidato>(Candidato entity)
        {   
            _context.Update(entity);
        }

        public async Task<Candidato[]> GetAllCandidatos()
        {   
            
            IQueryable<Candidato> query = _context.Candidato;
            

            query = query.Include(vc => vc.Vaga_Candidato)
            .ThenInclude(vc => vc.Vaga)
            .AsNoTracking()
            .OrderByDescending(c => c.Id);
                        

            return await query.ToArrayAsync();
            
        }

        public Candidato GetCandidatoAsyncById(int id_candidato)
        {
            IQueryable<Candidato> query = _context.Candidato;

            //query = query.Include(a=> a.VagaCandidato);
            
            
            query = query.AsNoTracking()
            .Where(a => a.Id == id_candidato)
            .Include(v => v.Vaga_Candidato)
            .ThenInclude(v => v.Vaga);

            return query.FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
            
        }
    }
}