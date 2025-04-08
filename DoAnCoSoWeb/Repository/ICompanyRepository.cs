using DoAnCoSoWeb.Models;

namespace DoAnCoSoWeb.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Hang>> GetAllAsync();
        Task<Hang> GetByIdAsync(int id);
        Task AddAsync(Hang conpany);
        Task UpdateAsync(Hang conpany);
        Task DeleteAsync(int id);
    }
}
