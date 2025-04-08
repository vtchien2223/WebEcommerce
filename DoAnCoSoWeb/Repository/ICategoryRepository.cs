using DoAnCoSoWeb.Models;

namespace DoAnCoSoWeb.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Loaisanpham>> GetAllAsync();
        Task<Loaisanpham> GetByIdAsync(int id);
        Task AddAsync(Loaisanpham category);
        Task UpdateAsync(Loaisanpham category);
        Task DeleteAsync(int id);
    }
}
