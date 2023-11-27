using Microsoft.AspNetCore.Mvc;
using codechemist.Data.IRepository;
using codechemist.Models.ViewModels;
using Microsoft.AspNetCore.StaticFiles;

namespace codechemist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {

        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var _data = await _exerciseRepository.GetAllAsync();


            return Ok(_data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var _data = await _exerciseRepository.GetByIdAsync(id);


            return Ok(_data);
        }


        [HttpPost]
        public async Task<IActionResult> AddASync([FromForm] ExerciseVM data)
        {

            // if (!ModelState.IsValid) return View(data);
            await _exerciseRepository.AddAsync(data);


            return Ok(data);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateByIdAsync(int id, [FromForm][FromBody] ExerciseVM data)
        {
            var _data = await _exerciseRepository.UpdateByIdAsync(id, data);

            return Ok(_data);

        }




        [HttpDelete("{id}")]


        public async Task<IActionResult> DeleteByIdAsync(int id)
        {


            var _data = await _exerciseRepository.GetByIdAsync(id);
            //    if (_data == null) return View("NotFound");

            await _exerciseRepository.DeleteByIdAsync(id);
            return Ok();
        }
        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }



    }
}

