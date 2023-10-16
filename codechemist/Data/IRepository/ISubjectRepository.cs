using codechemist.Models;
using codechemist.Models.ViewModels;

namespace codechemist.Data.IRepository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<Subject> GetByIdAsync(int id);

        Task AddAsync(SubjectVM data);

        Task DeleteByIdAsync(int id);

        //   Task<Technology> UpdateByIdAsync(int id, Subject data);
    }
}
