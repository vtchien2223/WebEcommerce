using DoAnCoSoWeb.Models;
using System.Threading.Tasks;

namespace DoAnCoSoWeb.Repository
{
    public interface IRankRepository
    {
        Task<IEnumerable<Rank>> GetAllAsync();
        Task<Rank> GetByIdAsync(int id);
        Task<int?> GetRankIdByNameAsync(string tenRank); // Phương thức mới
        Task AddAsync(Rank rank);
        Task UpdateAsync(Rank rank);
        Task DeleteAsync(int id);
    }
}
