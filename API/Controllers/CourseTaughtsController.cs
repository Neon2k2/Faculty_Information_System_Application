using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTaughtsController : ControllerBase
    {
        private readonly ICourseTaughtRepository _repository;
        public CourseTaughtsController(ICourseTaughtRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var CourseTautList = _repository.GetCourseTaught();
            return Ok(CourseTautList);

        }
        [HttpPost]
        public IActionResult Post(CourseTaught courTaut)
        {
            CourseTaught obj = _repository.AddCourseTaught(courTaut);
            return CreatedAtAction("get", new { Id = obj.CourseId }, obj);
        }


        [HttpDelete]
        [Route("{courseTaughtId}")]
        public IActionResult Delete(int courseTaughtId)
        {
            bool result = _repository.DeleteCourseTaught(courseTaughtId);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{courseTaughtId}")]
        public IActionResult Get(int courseTaughtId)
        {
            CourseTaught obj = _repository.SearchCourseTaught(courseTaughtId);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{courseTaughtId}")]

        public IActionResult Put(int courseTaughtId, [FromBody] CourseTaught courTaut)
        {
            _repository.UpdateCourseTaught(courseTaughtId, courTaut);
            return Ok();
        }
    }
}
