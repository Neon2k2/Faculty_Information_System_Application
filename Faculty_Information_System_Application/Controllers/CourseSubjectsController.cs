using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectsController : ControllerBase
    {
        private ICourseSubjectRepository _repository;
        public CourseSubjectsController(ICourseSubjectRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var CourseSubList = _repository.GetCourseSubject();
            return Ok(CourseSubList);

        }
        [HttpPost]
        public IActionResult Post(CourseSubject courSub)
        {
            CourseSubject obj = _repository.AddCourseSubject(courSub);
            return CreatedAtAction("get", new { Id = obj.CourseId }, obj);
        }


        [HttpDelete]
        [Route("{courseSubjectId}")]
        public IActionResult Delete(int courseSubjectId)
        {
            bool result = _repository.DeleteCourseSubject(courseSubjectId);
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
        [Route("{courseSubjectId}")]
        public IActionResult Get(int courseSubjectId)
        {
            CourseSubject obj = _repository.SearchCourseSubject(courseSubjectId);
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
        [Route("{courseSubjectId}")]
        public IActionResult Put(int courseSubjectId, [FromBody] CourseSubject courSub)
        {
            _repository.UpdateCourseSubject(courseSubjectId, courSub);
            return Ok();
        }
    }
}
