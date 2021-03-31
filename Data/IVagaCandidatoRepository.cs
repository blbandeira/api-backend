using System.Threading.Tasks;
using api_backend.Models;

namespace api_backend.Data
{
    public interface IVagaCandidatoRepository
    {
        void add<Vaga>(Vaga entity);

        Task<bool> SaveChangesAsync();

        
        Task<Vaga_Candidato[]> GetAllVagaCandidato();

        Vaga_Candidato GetVagaCandidatoAsyncById(int id);
    }
}