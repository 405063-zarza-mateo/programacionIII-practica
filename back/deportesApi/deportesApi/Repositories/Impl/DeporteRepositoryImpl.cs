using deportesApi.models;
using Microsoft.EntityFrameworkCore;

namespace deportesApi.Repositories.Impl

{
    public class DeporteRepositoryImpl : IDeporteRepository
    {
        private readonly db_aa579f_prog3w1Context _context;

        public DeporteRepositoryImpl(db_aa579f_prog3w1Context context)
        {
            _context = context;
        }

        public async Task<Deporte> GetDeporteByIdAsync(Guid id)
        {
            return await _context.Deportes.FindAsync(id);
        }

        public async Task<List<Deporte>> GetDeportesAsync()
        {
            return await _context.Deportes.ToListAsync();

        }
    }
}

