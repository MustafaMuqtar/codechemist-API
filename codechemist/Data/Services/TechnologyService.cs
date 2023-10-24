using codechemist.Data.IRepository;
using codechemist.Data.RequestHelpers;
using codechemist.Models;
using codechemist.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace codechemist.Data.Services
{
    public class TechnologyService : ITechnologyRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IPhotoRepository _photoRepository;

        public TechnologyService(AppDbContext appDbContext, IPhotoRepository photoRepository)
        {
            _appDbContext = appDbContext;
            _photoRepository = photoRepository;

        }

        public async Task AddAsync(TechnologyVM data)
        {
            var resultPhoto = await _photoRepository.AddPhotoAsync(data.Image);

            var _data = new Technology()
            {
                Title = data.Title,
                Image = resultPhoto.Url.ToString(),



            };
            _data.PublicId = resultPhoto.PublicId;
            await _appDbContext.Technologys.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();



        }

        public async Task DeleteByIdAsync(int id)
        {
            var _data = await _appDbContext.Technologys.FirstOrDefaultAsync(i => i.Id == id);

            if (_data != null)
            {

                if (!string.IsNullOrEmpty(_data.PublicId))
                {
                    await _photoRepository.DeletePhotoAsync(_data.PublicId);
                }
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
                            Content = n.Content
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
                        Title = n.Title,
                        LessonSubjects = n.Subjects.Select(n => new TechnologySubjectVM()
                        {
                            Id = n.Id,
                            Title = n.Title,
                            Content = n.Content
                        }).ToList()
                    }).ToList()
                }).FirstAsync();

            return _data;
        }

        public async Task<Technology> UpdateByIdAsync(int id, TechnologyVM data)
        {
            var _data = await _appDbContext.Technologys.FirstOrDefaultAsync(i => i.Id == id);
            var resultPhoto = await _photoRepository.AddPhotoAsync(data.Image);

            if (!string.IsNullOrEmpty(_data.PublicId))
            {
                await _photoRepository.DeletePhotoAsync(_data.PublicId);
            }

            if (_data != null)
            {
                _data.Title = data.Title;
                _data.Image = resultPhoto.Url.ToString();
                _data.PublicId = resultPhoto.PublicId;



                await _appDbContext.SaveChangesAsync();
            }


            return _data;


        }

    }
}

