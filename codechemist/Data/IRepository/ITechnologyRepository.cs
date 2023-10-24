using codechemist.Data.RequestHelpers;
using codechemist.Models;
using codechemist.Models.ViewModels;

namespace codechemist.Data.IRepository
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<TechnologyLessonVM>> GetAllAsync();
        Task<TechnologyLessonVM> GetByIdAsync(int id);

        Task AddAsync(TechnologyVM data);

        Task DeleteByIdAsync(int id);

        Task<Technology> UpdateByIdAsync(int id, TechnologyVM data);
    }
}
