using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyRepository _repository;
        public FacultiesController(IFacultyRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var FacultyList = _repository.GetFaculty();
            return Ok(FacultyList);

        }
        [HttpPost]
        public IActionResult Post(Faculty fac)
        {
            Faculty obj = _repository.AddFaculty(fac);
            return CreatedAtAction("get", new
            {
                Id = obj.FacultyId
            }, obj);
        }


        [HttpDelete]
        [Route("{facultyId}")]

        public IActionResult Delete(int facultyId)
        {
            bool result = _repository.DeleteFaculty(facultyId);
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
        [Route("{FacultyName}")]
        public IActionResult Get(int facultyName)
        {
            Faculty obj = _repository.SearchFaculty(facultyName);
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
        [Route("{facultyId}")]
        public IActionResult Put(int facultyId, [FromBody] Faculty fac)
        {
            _repository.UpdateFaculty(facultyId, fac);
            return Ok();
        }
    }
}
