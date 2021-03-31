using System.Linq;
using System.Threading.Tasks;
using api_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace api_backend.Data
{
    public class VagaRepository : IVagaRepository
    {

        readonly MyDbContext _context;

        public VagaRepository(MyDbContext context)
        {
            _context = context;
        }
        public void add<Vaga>(Vaga entity)
        {
            _context.Add(entity);
        }

        public async Task<Vaga[]> GetAllVagas(bool includeVagas)
        {
            IQueryable<Vaga> query = _context.Vaga;

            query = query.Include(vc => vc.Vaga_Candidato).ThenInclude(vc => vc.Candidato);

            query = query.OrderByDescending(a => a.Id);
            
            return await query.ToArrayAsync();
        }

        public Vaga GetVagaAsyncById(int id_candidato)
        {
           IQueryable<Vaga> query = _context.Vaga;

            //query = query.Include(a=> a.VagaCandidato);
            
            
            query = query.AsNoTracking()
            .Where(a => a.Id == id_candidato)
            .Include(v => v.Vaga_Candidato)
            .ThenInclude(v => v.Candidato);

            return query.FirstOrDefault();
        }

       public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
            
        }

        public void Update<Vaga>(Vaga entity)
        {
            _context.Update(entity);
        }
    }
}