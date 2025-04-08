using DoAnCoSoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSoWeb.Repository
{
    public class EFWarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _context;
        public EFWarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Kho>> GetAllAsync()
        {
            return await _context.khos.ToListAsync();
        }
        public async Task<Kho> GetByIdAsync(int id)
        {
            return await _context.khos.FindAsync(id);
        }
        public async Task AddAsync(Kho warehouse)
        {
            _context.khos.Add(warehouse);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Kho warehouse)
        {
            _context.khos.Update(warehouse);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var warehouse = await _context.khos.FindAsync(id);
            _context.khos.Remove(warehouse);
            await _context.SaveChangesAsync();
        }
    }
}
