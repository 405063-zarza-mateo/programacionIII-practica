using deportesApi.models;

namespace deportesApi.Repositories
{
    public interface IDeporteRepository
    {
        Task<List<Deporte>> GetDeportesAsync();
        Task<Deporte> GetDeporteByIdAsync(Guid id);
    }
}
