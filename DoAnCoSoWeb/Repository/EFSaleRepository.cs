using DoAnCoSoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSoWeb.Repository
{
    public class EFSaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public EFSaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.sales.ToListAsync();
        }
        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _context.sales.FindAsync(id);
        }
        public async Task AddAsync(Sale sale)
        {
            _context.sales.Add(sale);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Sale sale)
        {
            _context.sales.Update(sale);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var sale = await _context.sales.FindAsync(id);
            _context.sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}
