using deportesApi.models;
using deportesApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace deportesApi.Services.Impl
{
    public class SocioService : ISocioService
    {
        private readonly ISocioRepository _repositorySocio;
        private readonly IDeporteRepository _repositoryDeporte;

        public SocioService(ISocioRepository repositorySocio, IDeporteRepository repositoryDeporte)
        {
            _repositorySocio = repositorySocio;
            _repositoryDeporte = repositoryDeporte;
        }

        public async Task<List<Socio>> GetAllAsync()
        {
            return await _repositorySocio.GetAllAsync();
        }



        public async Task<Socio> GetByDni(string dni)
        {
            return await _repositorySocio.GetByDNIAsync(dni);
        }

        public async Task<Socio> GetById(Guid id)
        {
            Socio socio = await _repositorySocio.GetByIdAsync(id);
            socio.IdDeporteNavigation = await _repositoryDeporte.GetDeporteByIdAsync(id);
            return socio;
        }

        public async Task<Socio> PostSocioAsync(Socio socio)
        {
            if (await _repositorySocio.GetByDNIAsync(socio.Dni) != null)
            {
                throw new Exception("El usuario ya esta registrado.");
            }
            return await _repositorySocio.PostSocioAsync(socio);
        }

        public async Task<List<Deporte>> GetDeportesAsync()
        {
            return await _repositoryDeporte.GetDeportesAsync();
        }
    }
}
