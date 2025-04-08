using DoAnCoSoWeb.Models;

namespace DoAnCoSoWeb.Repository
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Kho>> GetAllAsync();
        Task<Kho> GetByIdAsync(int id);
        Task AddAsync(Kho warehouse);
        Task UpdateAsync(Kho warehouse);
        Task DeleteAsync(int id);
    }
}
