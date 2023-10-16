using codechemist.Data.Extentions;
using codechemist.Data.RequestHelpers;
using codechemist.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using codechemist.Data.IRepository;
using codechemist.Models.ViewModels;

namespace codechemist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILessonRepository _lessonRepository;

        public LessonController(ILessonRepository lessonRepository, AppDbContext appDbContext)
        {
            _lessonRepository = lessonRepository;
            _appDbContext = appDbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var _data = await _lessonRepository.GetAllAsync();


            return Ok(_data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var _data = await _lessonRepository.GetByIdAsync(id);


            return Ok(_data);
        }


        [HttpPost]
        public async Task<IActionResult> AddASync([FromForm] LessonVM data)
        {

            // if (!ModelState.IsValid) return View(data);
            await _lessonRepository.AddAsync(data);


            return Ok(data);
        }

        /*
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateByIdAsync(int id, [FromForm][FromBody] ContentVM data)
        {
            var _data = await _contentRepository.UpdateByIdAsync(id, data);

            return Ok(_data);

        }

        */


        [HttpDelete("{id}")]


        public async Task<IActionResult> DeleteByIdAsync(int id)
        {


            var _data = await _lessonRepository.GetByIdAsync(id);
            //    if (_data == null) return View("NotFound");

            await _lessonRepository.DeleteByIdAsync(id);
            return Ok();
        }




    }
}

