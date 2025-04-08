using DoAnCoSoWeb.Models;

namespace DoAnCoSoWeb.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Sanpham>> GetAllAsync();
        Task<Sanpham> GetByIdAsync(int id);
        Task AddAsync(Sanpham sanpham);
        Task UpdateAsync(Sanpham sanpham);
        Task DeleteAsync(int id);
    }
}
