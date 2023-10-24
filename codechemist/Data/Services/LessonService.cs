using codechemist.Data.IRepository;
using codechemist.Models.ViewModels;
using codechemist.Models;
using Microsoft.EntityFrameworkCore;

namespace codechemist.Data.Services
{
    public class LessonService : ILessonRepository
    {
        private readonly AppDbContext _appDbContext;

        public LessonService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task AddAsync(LessonVM data)
        {

            var _data = new Lesson()
            {
                Title = data.Title,
                TechnologyId = data.TechnologyId

            };
            await _appDbContext.Lessons.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var _data = await _appDbContext.Lessons.FirstOrDefaultAsync(i => i.Id == id);

            if (_data != null)
            {
                _appDbContext.Lessons.Remove(_data);
                await _appDbContext.SaveChangesAsync();

            }


        }

        public async Task<IEnumerable<Lesson>> GetAllAsync()
        {
            var _data = await _appDbContext.Lessons.ToListAsync();
            return _data;

        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            var _data = await _appDbContext.Lessons.FirstOrDefaultAsync(i => i.Id == id);

            return _data;
        }

        public async Task<Lesson> UpdateByIdAsync(int id, LessonVM data)
        {
            var _data = await _appDbContext.Lessons.FirstOrDefaultAsync(i => i.Id == id);


            if (_data != null)
            {
                _data.Title = data.Title;

                _data.TechnologyId = data.TechnologyId;


                await _appDbContext.SaveChangesAsync();
            }


            return _data;


        }

    }
}

