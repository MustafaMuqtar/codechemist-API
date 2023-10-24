using Microsoft.AspNetCore.Mvc;
using codechemist.Data.IRepository;
using codechemist.Models.ViewModels;

namespace codechemist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {

        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var _data = await _subjectRepository.GetAllAsync();


            return Ok(_data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var _data = await _subjectRepository.GetByIdAsync(id);


            return Ok(_data);
        }


        [HttpPost]
        public async Task<IActionResult> AddASync([FromForm] SubjectVM data)
        {

            // if (!ModelState.IsValid) return View(data);
            await _subjectRepository.AddAsync(data);


            return Ok(data);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateByIdAsync(int id, [FromForm][FromBody] SubjectVM data)
        {
            var _data = await _subjectRepository.UpdateByIdAsync(id, data);

            return Ok(_data);

        }




        [HttpDelete("{id}")]


        public async Task<IActionResult> DeleteByIdAsync(int id)
        {


            var _data = await _subjectRepository.GetByIdAsync(id);
            //    if (_data == null) return View("NotFound");

            await _subjectRepository.DeleteByIdAsync(id);
            return Ok();
        }




    }
}

