using DoAnCoSoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSoWeb.Repository
{
    public class EFRankRepository : IRankRepository
    {
        private readonly ApplicationDbContext _context;
        public EFRankRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rank>> GetAllAsync()
        {
            return await _context.ranks.ToListAsync();
        }
        public async Task<Rank> GetByIdAsync(int id)
        {
            return await _context.ranks.FindAsync(id);
        }
        public async Task AddAsync(Rank rank)
        {
            _context.ranks.Add(rank);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Rank rank)
        {
            _context.ranks.Update(rank);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var rank = await _context.ranks.FindAsync(id);
            _context.ranks.Remove(rank);
            await _context.SaveChangesAsync();
        }

        public async Task<int?> GetRankIdByNameAsync(string tenRank)
        {
            var rank = await _context.ranks.FirstOrDefaultAsync(r => r.TenRank == tenRank);
            return rank?.Id; // Trả về Id của Rank hoặc null nếu không tìm thấy
        }
    }
}
