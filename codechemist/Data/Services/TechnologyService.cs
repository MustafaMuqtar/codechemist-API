using codechemist.Data.IRepository;
using codechemist.Data.RequestHelpers;
using codechemist.Models;
using codechemist.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace codechemist.Data.Services
{
    public class TechnologyService : ITechnologyRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IFIleRepository _fIleRepository;

        public TechnologyService(AppDbContext appDbContext, IFIleRepository fIleRepository)
        {
            _appDbContext = appDbContext;
            _fIleRepository = fIleRepository;

        }

        public async Task AddAsync(TechnologyVM data)
        {
            var file = await _fIleRepository.UploadImage(data.Image);

            var _data = new Technology()
            {
                Title = data.Title,
                Image = file.ToString(),



            };

            await _appDbContext.Technologys.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();



        }

        public async Task DeleteByIdAsync(int id)
        {
            string directory = "/Uploads/Images/";

            var _data = await _appDbContext.Technologys.FirstOrDefaultAsync(i => i.Id == id);
            _fIleRepository.RemoveFile(_data.Image, directory);

            if (_data != null)
            {


                _appDbContext.Technologys.Remove(_data);
                await _appDbContext.SaveChangesAsync();

            }


        }

        public async Task<IEnumerable<TechnologyLessonVM>> GetAllAsync()
        {
            var _data = await _appDbContext.Technologys
                .Select(n => new TechnologyLessonVM()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Image = n.Image,
                    TechnologyLessons = n.Lessons.Select(n => new TechnologyLessonSubjectVM()
                    {
                        Id = n.Id,
                        Title = n.Title,
                        LessonSubjects = n.Subjects.Select(n => new TechnologySubjectVM()
                        {
                            Id = n.Id,
                            Title = n.Title,
                            Content = n.Content,
                            SubjectsExercises = n.Exercises




                        }).ToList()

                    }).ToList()
                }).ToListAsync();


            return _data;

        }

        public async Task<TechnologyLessonVM> GetByIdAsync(int id)
        {
            var _data = await _appDbContext.Technologys.Where(i => i.Id == id)
                .Select(n => new TechnologyLessonVM()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Image = n.Image,
                    TechnologyLessons = n.Lessons.Select(n => new TechnologyLessonSubjectVM()
                    {
                        Id = n.Id,
                        Title = n.Title,
                        LessonSubjects = n.Subjects.Select(n => new TechnologySubjectVM()
                        {
                            Id = n.Id,
                            Title = n.Title,
                            Content = n.Content,
                            SubjectsExercises = n.Exercises

                        }).ToList()
                    }).ToList()
                }).FirstAsync();

            return _data;
        }

        public async Task<Technology> UpdateByIdAsync(int id, TechnologyVM data)
        {
            var _data = await _appDbContext.Technologys.FirstOrDefaultAsync(i => i.Id == id);
            var file = await _fIleRepository.UploadImage(data.Image);



            if (_data != null)
            {
                _data.Title = data.Title;
                _data.Image = file.ToString();



                await _appDbContext.SaveChangesAsync();
            }


            return _data;


        }

    }
}

