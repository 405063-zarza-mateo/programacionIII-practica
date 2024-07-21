using deportesApi.models;

namespace deportesApi.Repositories
{
    public interface ISocioRepository
    {
        Task<List<Socio>> GetAllAsync();
        Task<Socio> GetByIdAsync (Guid id);

        Task<Socio> PostSocioAsync   (Socio socio);

        Task<Socio> GetByDNIAsync (string dni);
    }
}
