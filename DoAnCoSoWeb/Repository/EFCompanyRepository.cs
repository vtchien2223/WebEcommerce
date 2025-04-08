using DoAnCoSoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSoWeb.Repository
{
    public class EFCompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public EFCompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Hang>> GetAllAsync()
        {
            return await _context.hangs.ToListAsync();
        }
        public async Task<Hang> GetByIdAsync(int id)
        {
            return await _context.hangs.FindAsync(id);
        }
        public async Task AddAsync(Hang company)
        {
            _context.hangs.Add(company);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Hang company)
        {
            _context.hangs.Update(company);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var company = await _context.hangs.FindAsync(id);
            _context.hangs.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
