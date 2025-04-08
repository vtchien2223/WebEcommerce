using DoAnCoSoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSoWeb.Repository
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Loaisanpham>> GetAllAsync()
        {
            return await _context.loaisanphams.ToListAsync();
        }
        public async Task<Loaisanpham> GetByIdAsync(int id)
        {
            return await _context.loaisanphams.FindAsync(id);
        }
        public async Task AddAsync(Loaisanpham category)
        {
            _context.loaisanphams.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Loaisanpham category)
        {
            _context.loaisanphams.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.loaisanphams.FindAsync(id);
            _context.loaisanphams.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
