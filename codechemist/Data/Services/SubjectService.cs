using codechemist.Data.IRepository;
using codechemist.Models.ViewModels;
using codechemist.Models;
using Microsoft.EntityFrameworkCore;

namespace codechemist.Data.Services
{
    public class SubjectService : ISubjectRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPhotoRepository _photoRepository;

        public SubjectService(AppDbContext appDbContext, IPhotoRepository photoRepository)
        {
            _appDbContext = appDbContext;
            _photoRepository = photoRepository;

        }

        public async Task AddAsync(SubjectVM data)
        {
            var resultPhoto = await _photoRepository.AddPhotoAsync(data.Content);

            var _data = new Subject()
            {
                Title = data.Title,
                Content = resultPhoto.Url.ToString(),



            };
            _data.PublicId = resultPhoto.PublicId;
            await _appDbContext.Subjects.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();

            /*  foreach (var id in data.CreatorIds)
               {
                   var _data_creator = new Content_Creator()
                   {
                       ContentId = _data.Id,
                       CreatorId = id,
                   };
                   await _appDbContext.Content_Creators.AddAsync(_data_creator);
                   await _appDbContext.SaveChangesAsync();
               }    */

        }

        public async Task DeleteByIdAsync(int id)
        {
            var _data = await _appDbContext.Subjects.FirstOrDefaultAsync(i => i.Id == id);

            if (_data != null)
            {

                if (!string.IsNullOrEmpty(_data.PublicId))
                {
                    await _photoRepository.DeletePhotoAsync(_data.PublicId);
                }
                _appDbContext.Subjects.Remove(_data);
                await _appDbContext.SaveChangesAsync();

            }


        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            var _data = await _appDbContext.Subjects.ToListAsync();
            return _data;

        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            var _data = await _appDbContext.Subjects.FirstOrDefaultAsync(i => i.Id == id);

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

