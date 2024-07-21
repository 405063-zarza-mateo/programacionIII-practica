using deportesApi.models;

namespace deportesApi.Services
{
    public interface ISocioService
    {
        Task<List<Socio>> GetAllAsync();
        Task<Socio> GetByDni(string dni);
        Task<Socio> GetById (Guid id);
        Task<Socio> PostSocioAsync(Socio socio);
        Task<List<Deporte>> GetDeportesAsync();
    }
}
