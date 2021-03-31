using System.Threading.Tasks;
using api_backend.Models;

namespace api_backend.Data
{
    public interface ICandidatoRepository
    {
        void add<Candidato>(Candidato entity);
        void Update<Candidato>(Candidato entity);

        Task<bool> SaveChangesAsync();

        //CANDIDATO
        Task<Candidato[]> GetAllCandidatos();

        Candidato GetCandidatoAsyncById(int id_candidato);
    }
}