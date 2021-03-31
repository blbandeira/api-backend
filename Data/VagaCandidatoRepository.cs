using System.Linq;
using System.Threading.Tasks;
using api_backend.Models;
using Microsoft.EntityFrameworkCore;
using api_backend.Data;


namespace api_backend.Data
{
    public class VagaCandidatoRepository : IVagaCandidatoRepository
    {

        readonly MyDbContext _context;
        public VagaCandidatoRepository(MyDbContext context)
        {
            _context = context;
        }
        public void add<Vaga>(Vaga entity)
        {
            _context.Add(entity);
        }

        public async Task<Vaga_Candidato[]> GetAllVagaCandidato()
        {   
            
            IQueryable<Vaga_Candidato> query = _context.Vaga_Candidato;
            

            query = query.Include(v => v.Vaga)
            .Include(c => c.Candidato)
            .AsNoTracking()
            .OrderByDescending(c => c.Id);
                        

            return await query.ToArrayAsync();
            
        }

        public Vaga_Candidato GetVagaCandidatoAsyncById(int id)
        {
           IQueryable<Vaga_Candidato> query = _context.Vaga_Candidato;
            

            query = query
            .Where(vc => vc.Id == id)
            .Include(v => v.Vaga)
            .Include(c => c.Candidato)
            .AsNoTracking() 
            ;
            
            return query.FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await (_context.SaveChangesAsync() ) > 0;
        }
    }
}