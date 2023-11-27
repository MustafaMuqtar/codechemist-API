using codechemist.Data.IRepository;
using codechemist.Models.ViewModels;
using codechemist.Models;
using Microsoft.EntityFrameworkCore;

namespace codechemist.Data.Services
{
    public class SubjectService : ISubjectRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFIleRepository _fIleRepository;

        public SubjectService(AppDbContext appDbContext, IFIleRepository fIleRepository)
        {
            _appDbContext = appDbContext;
            _fIleRepository = fIleRepository;

        }

        public async Task AddAsync(SubjectVM data)
        {
            var file = await _fIleRepository.UploadVideo(data.Content);

            var _data = new Subject()
            {
                Title = data.Title,
                Content = file.ToString(),
                LessonId = data.LessonId



            };
            await _appDbContext.Subjects.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            string directory = "/Uploads/Videos/";

            var _data = await _appDbContext.Subjects.FirstOrDefaultAsync(i => i.Id == id);
            _fIleRepository.RemoveFile(_data.Content, directory);

            if (_data != null)
            {


                _appDbContext.Subjects.Remove(_data);
                await _appDbContext.SaveChangesAsync();

            }


        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            var _data = await _appDbContext.Subjects.Include(n => n.Exercises).ToListAsync();
            return _data;

        }

        //            var _data = await _appDbContext.Subjects.Include(n => n.Exercises).ToListAsync();


        public async Task<Subject> GetByIdAsync(int id)
        {
            var _data = await _appDbContext.Subjects.FirstOrDefaultAsync(i => i.Id == id);

            return _data;
        }

        public async Task<Subject> UpdateByIdAsync(int id, SubjectVM data)
        {
            var _data = await _appDbContext.Subjects.FirstOrDefaultAsync(i => i.Id == id);
            var file = await _fIleRepository.UploadVideo(data.Content);



            if (_data != null)
            {
                _data.Title = data.Title;
                _data.Content = file.ToString();
                _data.LessonId = data.LessonId;

                await _appDbContext.SaveChangesAsync();
            }


            return _data;


        }

    }
}

