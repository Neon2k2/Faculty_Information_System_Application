using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private ISubjectRepository _repository;
        public SubjectsController(ISubjectRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var SubjectList = _repository.GetSubject();
            return Ok(SubjectList);

        }
        [HttpPost]
        public IActionResult Post(Subject sub)
        {
            Subject obj = _repository.AddSubject(sub);
            return CreatedAtAction("get", new
            {
                Id = obj.SubjectID
            }, obj);
        }


        [HttpDelete]
        [Route("{subjectId}")]
        public IActionResult Delete(int subjectId)
        {
            bool result = _repository.DeleteSubject(subjectId);
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
        [Route("{subjectId}")]
        public IActionResult Get(int subjectId)
        {
            Subject obj = _repository.SearchSubject(subjectId);
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
        [Route("{subjectId}")]

        public IActionResult Put(int subjectId, [FromBody] Subject sub)
        {
            _repository.UpdateSubject(subjectId, sub);
            return Ok();
        }
    }
}
