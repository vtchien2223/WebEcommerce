using DoAnCoSoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSoWeb.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Sanpham>> GetAllAsync()
        {
            /*return await _context.sanphams.Include(x=>x.Loaisanpham).ToListAsync();*/
            return await _context.sanphams
               .Include(p => p.loaisanpham)
               .Include(p => p.hang)
               .Include(p => p.Sale)
               .Include(p => p.Kho)
               .ToListAsync();
        }
        /*public async Task<Sanpham> GetByIdAsync(int id)
        {
            return await _context.sanphams.FindAsync(id);
        }*/
        public async Task<Sanpham> GetByIdAsync(int id)
        {
            return await _context.sanphams
                .Include(p => p.loaisanpham)
                .Include(p => p.hang)
                .Include(p => p.Sale)
                .Include(p => p.Kho)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Sanpham product)
        {
            _context.sanphams.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Sanpham product)
        {
            _context.sanphams.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.sanphams.FindAsync(id);
            _context.sanphams.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
