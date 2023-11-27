using codechemist.Data.IRepository;
using codechemist.Models.ViewModels;
using codechemist.Models;
using Microsoft.EntityFrameworkCore;

namespace codechemist.Data.Services
{
    public class ExerciseService : IExerciseRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IFIleRepository _fIleRepository;

        public ExerciseService(AppDbContext appDbContext, IFIleRepository fIleRepository)
        {
            _appDbContext = appDbContext;
            _fIleRepository = fIleRepository;

        }

        public async Task AddAsync(ExerciseVM data)
        {
            var file = await _fIleRepository.UploadPDF(data.PDF);

            var _data = new Exercise()
            {
                Title = data.Title,
                PDF = file.ToString(),
                SubjectId = data.SubjectId



            };
            await _appDbContext.Exercises.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            string directory = "/Uploads/PDFs/";

            var _data = await _appDbContext.Exercises.FirstOrDefaultAsync(i => i.Id == id);
            _fIleRepository.RemoveFile(_data.PDF, directory);

            if (_data != null)
            {


                _appDbContext.Exercises.Remove(_data);
                await _appDbContext.SaveChangesAsync();

            }


        }

        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            var _data = await _appDbContext.Exercises.ToListAsync();
            return _data;

        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            var _data = await _appDbContext.Exercises.FirstOrDefaultAsync(i => i.Id == id);

            return _data;
        }

        public async Task<Exercise> UpdateByIdAsync(int id, ExerciseVM data)
        {
            var _data = await _appDbContext.Exercises.FirstOrDefaultAsync(i => i.Id == id);
            var file = await _fIleRepository.UploadPDF(data.PDF);



            if (_data != null)
            {
                _data.Title = data.Title;
                _data.PDF = file.ToString();
                _data.SubjectId = data.SubjectId;

                await _appDbContext.SaveChangesAsync();
            }


            return _data;


        }


    }
}
