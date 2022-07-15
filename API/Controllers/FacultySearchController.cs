using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultySearchController : ControllerBase
    {
        private readonly IFacultySearchRepository _repository;

        public FacultySearchController(IFacultySearchRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{Fname}")]

        public IActionResult Get(string Fname)
        {
            Faculty obj = _repository.SearchFacultyByName(Fname);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
