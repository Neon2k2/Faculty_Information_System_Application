using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repository;
        public CoursesController (ICourseRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var CourseList = _repository.GetCourse();
            return Ok(CourseList);

        }
        [HttpPost]
        public IActionResult Post(Course cour)
        {
            Course obj = _repository.AddCourse(cour);
            return CreatedAtAction("get", new { Id = obj.CourseId }, obj);
        }


        [HttpDelete]
        [Route("{courseId}")]
        public IActionResult Delete(int courseId)
        {
            bool result = _repository.DeleteCourse(courseId);
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
        [Route("{courseId}")]
        public IActionResult Get(int courseId)
        {
            Course obj = _repository.SearchCourse(courseId);
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
        [Route("{courseId}")]
        public IActionResult Put(int courseId, [FromBody] Course cour)
        {
            _repository.UpdateCourse(courseId, cour);
            return Ok();
        }
    }
}
