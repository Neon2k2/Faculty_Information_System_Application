using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeRepository _repository;
        public DegreesController(IDegreeRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var DegreeList = _repository.GetDegree();
            return Ok(DegreeList);

        }
        [HttpPost]
        public IActionResult Post(Degree deg)
        {
            Degree obj = _repository.AddDegree(deg);
            return CreatedAtAction("get", new { Id = obj.DegreeId }, obj);
        }


        [HttpDelete]
        [Route("{degreeId}")]
        public IActionResult Delete(int degreeId)
        {
            bool result = _repository.DeleteDegree(degreeId);
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
        [Route("{degreeId}")]
        public IActionResult Get(int degreeId)
        {
            Degree obj = _repository.SearchDegree(degreeId);
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
        [Route("{degreeId}")]
        public IActionResult Put(int degreeId, [FromBody] Degree deg)
        {
            _repository.UpdateDegree(degreeId, deg);
            return Ok();
        }
    }
}
