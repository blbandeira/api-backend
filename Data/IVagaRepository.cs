using System.Threading.Tasks;
using api_backend.Models;

namespace api_backend.Data
{
    public interface IVagaRepository
    {
        void add<Vaga>(Vaga entity);
        void Update<Vaga>(Vaga entity);

        Task<bool> SaveChangesAsync();

        
        Task<Vaga[]> GetAllVagas(bool includeVagas);

        Vaga GetVagaAsyncById(int id_candidato);
    }
}