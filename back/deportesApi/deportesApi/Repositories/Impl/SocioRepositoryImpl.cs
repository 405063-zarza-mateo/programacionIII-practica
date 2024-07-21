using deportesApi.models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace deportesApi.Repositories.Impl
{
    public class SocioRepositoryImpl : ISocioRepository
    {
        private readonly db_aa579f_prog3w1Context _context;

        public SocioRepositoryImpl(db_aa579f_prog3w1Context context)
        {
            _context = context;
        }

        public async Task<List<Socio>> GetAllAsync()
        {
            return await _context.Socios.Include(socio => socio.IdDeporteNavigation).ToListAsync();
        }

        public async Task<Socio> GetByDNIAsync(string dni)
        {
            return await _context.Socios.FirstOrDefaultAsync(x => x.Dni == dni);
        }

        public async Task<Socio> GetByIdAsync(Guid id)
        {
            return await _context.Socios.FindAsync(id);
        }

        public async Task<Socio> PostSocioAsync(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
            await _context.SaveChangesAsync();
            return socio;
        }

    }
}
