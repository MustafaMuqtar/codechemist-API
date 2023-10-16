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

        /*   public async Task<Content> UpdateByIdAsync(int id, ContentVM data)
           {
               var _data = await _appDbContext.Contents.FirstOrDefaultAsync(i => i.Id == id);
               var resultPhoto = await _photoRepository.AddPhotoAsync(data.CoverImageURl);
               var resultAudio = await _photoRepository.AddAudioAsync(data.AudioPlayerURL);

               if (!string.IsNullOrEmpty(_data.PublicId))
               {
                   await _photoRepository.DeletePhotoAsync(_data.PublicId);
               }

               if (_data != null)
               {
                   _data.Title = data.Title;
                   _data.CoverImageURl = resultPhoto.Url.ToString();
                   _data.AudioPlayerURL = resultAudio.Url.ToString();
                   _data.Gengre = data.Gengre;
                   _data.Description = data.Description;
                   _data.PublicId = resultPhoto.PublicId;
                   _data.PublicId = resultAudio.PublicId;



                   await _appDbContext.SaveChangesAsync();
               }


               return _data;


           }*/

    }
}

