using codechemist.Data.RequestHelpers;
using codechemist.Models;
using codechemist.Models.ViewModels;

namespace codechemist.Data.IRepository
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetAllAsync();
        Task<Technology> GetByIdAsync(int id);

        Task AddAsync(TechnologyVM data);

        Task DeleteByIdAsync(int id);

        //    Task<Technology> UpdateByIdAsync(int id, Technology data);
    }
}
