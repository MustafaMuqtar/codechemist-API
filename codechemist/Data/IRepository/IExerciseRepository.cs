using codechemist.Models;
using codechemist.Models.ViewModels;

namespace codechemist.Data.IRepository
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise> GetByIdAsync(int id);

        Task AddAsync(ExerciseVM data);

        Task DeleteByIdAsync(int id);

        Task<Exercise> UpdateByIdAsync(int id, ExerciseVM data);
    }
}
